using DiscoverEgypt.Core.Features.CustomPlans.DTOs;

namespace DiscoverEgypt.Core.Features.CustomPlans.Interfaces
{
    public interface ICustomPlanService
    {
        Task<CustomPlanResponseDto> CreateCustomPlanAsync(string userId, CreateCustomPlanDto dto);
        Task<List<CustomPlanResponseDto>> GetMyPlansAsync(string userId);
        Task<CustomPlanResponseDto> GetByIdAsync(int id, string userId);
        Task UpdateCustomPlanAsync(int id, string userId, UpdateCustomPlanDto dto);
        Task DeleteCustomPlanAsync(int id, string userId);
        Task<List<CustomPlanResponseDto>> GetAllAsync();
    }
}