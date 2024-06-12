using BeeApp.Domain.Entities;
using BeeApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Infrastructure.Seeders
{
    public class BeeAppSeeder
    {
        private readonly BeeAppDbContext _dbcontext;
        public BeeAppSeeder(BeeAppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        // BJ: Seed default data if database is empty
        public async Task Seed()
        {
            if (await _dbcontext.Database.CanConnectAsync())
            {
                if (!_dbcontext.Inspections.Any())
                {
                    var inspection1 = new Inspection()
                    {
                        CreatedAt = DateTime.Now,
                        QueenBee = true,
                        BeeBrood = true,
                        Eggs = true,
                        Feed = true,
                        QueenCell = false,
                        BeeBread = true,
                        Notes = "Initial inspetion.",
                        BeehiveDetails = new()
                        {
                            Id = 1,
                            BeehiveType = "Wielkopolski",
                            QueenType = "Krainka",
                            LastInspection = DateTime.Now,
                        }
                    };
                    _dbcontext.Inspections.Add(inspection1);
                    await _dbcontext.SaveChangesAsync();
                }
            }
        }
    }
}
