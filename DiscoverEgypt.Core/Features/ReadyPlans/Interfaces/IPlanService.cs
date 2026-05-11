using DiscoverEgypt.Core.Features.ReadyPlans.DTOs;

namespace DiscoverEgypt.Core.Features.ReadyPlans.Interfaces
{
    public interface IPlanService
    {
        Task<ReadyPlanResponseDto> CreateReadyPlanAsync(CreateReadyPlanDto dto);
        Task<List<ReadyPlanResponseDto>> GetAllReadyPlansAsync();
        Task<ReadyPlanResponseDto> GetReadyPlanByIdAsync(int id);
        Task DeleteReadyPlanAsync(int id);
    }
}