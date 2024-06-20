using BeeApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Domain.Interfaces
{
    public interface IInspectionRepository
    {
        Task Create(Domain.Entities.Inspection inspection);
        Task<IEnumerable<Domain.Entities.Inspection>> GetAll();
        Task<Domain.Entities.Inspection> GetById(int id);
    }
}
