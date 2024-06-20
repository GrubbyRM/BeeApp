using BeeApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Aplication.Inspection.Queries.GetAllInspections
{
    public class GetAllInspectionsQueryHandler : IRequestHandler<GetAllInspectionsQuery, IEnumerable<Domain.Entities.Inspection>>
    {
        private readonly IInspectionRepository _inspectionRepository;
        public GetAllInspectionsQueryHandler(IInspectionRepository inspectionRepository)
        {
            _inspectionRepository = inspectionRepository;
        }
        public async Task<IEnumerable<Domain.Entities.Inspection>> Handle(GetAllInspectionsQuery request, CancellationToken cancellationToken)
        {
            var inspections = await _inspectionRepository.GetAll();
            return inspections;
        }
    }
}
