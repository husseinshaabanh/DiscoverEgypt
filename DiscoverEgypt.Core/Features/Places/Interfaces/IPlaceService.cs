using DiscoverEgypt.Core.Features.Places.DTOs;

namespace DiscoverEgypt.Core.Features.Places.Interfaces
{
    public interface IPlaceService
    {
        Task<List<PlaceDto>> GetAllAsync(string? city = null, int? categoryId = null);
        Task<PlaceDto> GetByIdAsync(int id);
        Task<PlaceDto> CreateAsync(CreatePlaceDto dto);
        Task UpdateAsync(int id, UpdatePlaceDto dto);
        Task DeleteAsync(int id);
    }
}