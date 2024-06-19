using BeeApp.Domain.Entities;
using BeeApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Aplication.Services
{
    public class InspectionService : IInspectionService
    {
        private readonly IInspectionRepository _inspectionRepository;
        public InspectionService(IInspectionRepository inspectionRepository)
        {
            _inspectionRepository = inspectionRepository;
        }
        public async Task Create(Domain.Entities.Inspection inspection)
        {

            await _inspectionRepository.Create(inspection);
        }
    }
}
