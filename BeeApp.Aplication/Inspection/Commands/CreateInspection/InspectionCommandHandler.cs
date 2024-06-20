using BeeApp.Domain.Entities;
using BeeApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Aplication.Inspection.Commands.CreateInspection
{
    public class InspectionCommandHandler : IRequestHandler<CreateInspectionCommand>
    {
        private readonly IInspectionRepository _inspectionRepository;
        public InspectionCommandHandler(IInspectionRepository inspectionRepository)
        {
            _inspectionRepository = inspectionRepository;
        }
        public async Task<Unit> Handle(CreateInspectionCommand request, CancellationToken cancellationToken)
        {
            await _inspectionRepository.Create(request);
            return Unit.Value;
        }
    }
}
