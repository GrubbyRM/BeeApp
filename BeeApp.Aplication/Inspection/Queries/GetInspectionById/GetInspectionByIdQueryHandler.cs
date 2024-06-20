using BeeApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Aplication.Inspection.Queries.GetInspectionById
{
    public class GetInspectionByIdQueryHandler : IRequestHandler<GetInspectionByIdQuery, Domain.Entities.Inspection>
    {
        private readonly IInspectionRepository _inspectionRepository;
        public GetInspectionByIdQueryHandler(IInspectionRepository inspectionRepository)
        {
            _inspectionRepository = inspectionRepository;
        }
        public async Task<Domain.Entities.Inspection> Handle(GetInspectionByIdQuery request, CancellationToken cancellationToken)
        {
            var inspection = await _inspectionRepository.GetById(request.InspectionId);
            return inspection;
        }
    }
}
