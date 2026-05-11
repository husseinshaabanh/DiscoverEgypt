using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Features.ReadyPlans.Interfaces;

namespace DiscoverEgypt.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        IReadyPlanRepository ReadyPlans { get; }
        Task<int> CompleteAsync();
    }
}