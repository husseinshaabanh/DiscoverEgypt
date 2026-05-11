using DiscoverEgypt.Core.Interfaces;
namespace DiscoverEgypt.Core.Features.ReadyPlans.Interfaces
{
    public interface IReadyPlanRepository : IGenericRepository<Entities.ReadyPlan>
{
    Task<IReadOnlyList<Entities.ReadyPlan>> GetAllWithPlacesAsync();
    Task<Entities.ReadyPlan?> GetByIdWithPlacesAsync(int id);
}
}
