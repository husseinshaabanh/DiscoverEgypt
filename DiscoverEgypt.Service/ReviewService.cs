using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Exceptions;
using DiscoverEgypt.Core.Features.Review.DTOs;
using DiscoverEgypt.Core.Features.Review.Interfaces;
using DiscoverEgypt.Core.Interfaces;

namespace DiscoverEgypt.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Add Review
        public async Task AddReviewAsync(string userId, CreateReviewDto dto)
        {
            var place = await _unitOfWork.Repository<Place>().GetByIdAsync(dto.PlaceId);
            if (place == null)
                throw new NotFoundException("Place not found");

            var exists = await _unitOfWork.Repository<Review>().GetFirstAsync(
                predicate: r => r.TouristId == userId && r.PlaceId == dto.PlaceId);

            if (exists != null)
                throw new ConflictException("You have already reviewed this place");

            var review = new Review
            {
                TouristId = userId,
                PlaceId = dto.PlaceId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Repository<Review>().AddAsync(review);
            await _unitOfWork.CompleteAsync();
        }

        // Get Reviews By Place
        public async Task<List<ReviewDto>> GetReviewsByPlaceAsync(int placeId)
        {
            var reviews = await _unitOfWork.Repository<Review>().GetAllAsync(
                predicate: r => r.PlaceId == placeId,
                include: q => q.Include(r => r.Tourist)
                               .ThenInclude(t => t.User));

            return _mapper.Map<List<ReviewDto>>(
                reviews.OrderByDescending(r => r.CreatedAt));
        }

        // Update Review
        public async Task UpdateReviewAsync(int reviewId, string userId, UpdateReviewDto dto)
        {
            var review = await _unitOfWork.Repository<Review>().GetByIdAsync(reviewId);

            if (review == null)
                throw new NotFoundException("Review not found");

            if (review.TouristId != userId)
                throw new ForbiddenException("You don't have access to this review");

            review.Rating = dto.Rating;
            review.Comment = dto.Comment;

            _unitOfWork.Repository<Review>().Update(review);
            await _unitOfWork.CompleteAsync();
        }

        // Delete Review
        public async Task DeleteReviewAsync(int reviewId, string userId)
        {
            var review = await _unitOfWork.Repository<Review>().GetByIdAsync(reviewId);

            if (review == null)
                throw new NotFoundException("Review not found");

            if (review.TouristId != userId)
                throw new ForbiddenException("You don't have access to this review");

            _unitOfWork.Repository<Review>().Delete(review);
            await _unitOfWork.CompleteAsync();
        }
    }
}