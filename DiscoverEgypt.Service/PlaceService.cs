using AutoMapper;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Exceptions;
using DiscoverEgypt.Core.Features.Places.DTOs;
using DiscoverEgypt.Core.Features.Places.Interfaces;
using DiscoverEgypt.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiscoverEgypt.Service
{
    public class PlaceService : IPlaceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlaceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Get All
        public async Task<List<PlaceDto>> GetAllAsync(string? city = null, int? categoryId = null)
        {
            var places = await _unitOfWork.Repository<Place>().GetAllAsync(
                predicate: p =>
                    (city == null || p.City.ToLower() == city.ToLower()) &&
                    (categoryId == null || p.CategoryId == categoryId),
                include: q => q.Include(p => p.Category));

            return _mapper.Map<List<PlaceDto>>(places);
        }

        // Get By Id
        public async Task<PlaceDto> GetByIdAsync(int id)
        {
            var place = await _unitOfWork.Repository<Place>().GetFirstAsync(
                predicate: p => p.Id == id,
                include: q => q.Include(p => p.Category));

            if (place == null)
                throw new NotFoundException("Place not found");

            return _mapper.Map<PlaceDto>(place);
        }

        // Create
        public async Task<PlaceDto> CreateAsync(CreatePlaceDto dto)
        {
            var place = _mapper.Map<Place>(dto);

            await _unitOfWork.Repository<Place>().AddAsync(place);
            await _unitOfWork.CompleteAsync();

            var created = await _unitOfWork.Repository<Place>().GetFirstAsync(
                predicate: p => p.Id == place.Id,
                include: q => q.Include(p => p.Category));

            return _mapper.Map<PlaceDto>(created!);
        }

        // Update
        public async Task UpdateAsync(int id, UpdatePlaceDto dto)
        {
            var place = await _unitOfWork.Repository<Place>().GetByIdAsync(id);

            if (place == null)
                throw new NotFoundException("Place not found");

            // Partial update
            if (dto.Name != null) place.Name = dto.Name;
            if (dto.Description != null) place.Description = dto.Description;
            if (dto.City != null) place.City = dto.City;
            if (dto.TicketPrice.HasValue) place.TicketPrice = dto.TicketPrice.Value;
            if (dto.CategoryId.HasValue) place.CategoryId = dto.CategoryId.Value;
            if (dto.OpeningTime.HasValue) place.OpeningTime = dto.OpeningTime.Value;
            if (dto.ClosingTime.HasValue) place.ClosingTime = dto.ClosingTime.Value;
            if (dto.AverageVisitDuration.HasValue) place.AverageVisitDuration = dto.AverageVisitDuration.Value;

            if (dto.Latitude.HasValue || dto.Longitude.HasValue)
            {
                place.Location = new Location
                {
                    Latitude = dto.Latitude ?? place.Location.Latitude,
                    Longitude = dto.Longitude ?? place.Location.Longitude
                };
            }

            _unitOfWork.Repository<Place>().Update(place);
            await _unitOfWork.CompleteAsync();
        }

        // Delete
        public async Task DeleteAsync(int id)
        {
            var place = await _unitOfWork.Repository<Place>().GetByIdAsync(id);

            if (place == null)
                throw new NotFoundException("Place not found");

            _unitOfWork.Repository<Place>().Delete(place);
            await _unitOfWork.CompleteAsync();
        }
    }
}