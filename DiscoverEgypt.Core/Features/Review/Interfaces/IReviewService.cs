using DiscoverEgypt.Core.Features.Review.DTOs;

namespace DiscoverEgypt.Core.Features.Review.Interfaces
{
    public interface IReviewService
    {
        Task AddReviewAsync(string userId, CreateReviewDto dto);
        Task<List<ReviewDto>> GetReviewsByPlaceAsync(int placeId);
        Task UpdateReviewAsync(int reviewId, string userId, UpdateReviewDto dto);
        Task DeleteReviewAsync(int reviewId, string userId);
    }
}