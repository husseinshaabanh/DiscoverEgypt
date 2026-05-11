using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Features.ReadyPlans.Interfaces;
using DiscoverEgypt.Repository.Data.DBContext;

namespace DiscoverEgypt.Repository
{
    public class ReadyPlanRepository : GenericRepository<ReadyPlan>, IReadyPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public ReadyPlanRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ReadyPlan>> GetAllWithPlacesAsync()
        {
            return await _context.ReadyPlans
                .Include(p => p.PlanPlaces)
                .ToListAsync();
        }

        public async Task<ReadyPlan?> GetByIdWithPlacesAsync(int id)
        {
            return await _context.ReadyPlans
                .Include(p => p.PlanPlaces)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
