using BeeApp.Domain.Entities;
using BeeApp.Domain.Interfaces;
using BeeApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Infrastructure.Repositories
{
    internal class InspectionRepository : IInspectionRepository
    {
        private readonly BeeAppDbContext _dbContext;
        public InspectionRepository(BeeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Domain.Entities.Inspection inspection)
        {
            _dbContext.Add(inspection);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Inspection>> GetAll()
        => await _dbContext.Inspections.ToListAsync();

        public Task<Domain.Entities.Inspection> GetById(int id)
        => _dbContext.Inspections.FirstAsync(c=> c.Id == id);
    }
}
