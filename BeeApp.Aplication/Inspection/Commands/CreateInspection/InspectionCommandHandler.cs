using BeeApp.Aplication.ApplicationUser;
using BeeApp.Domain.Entities;
using BeeApp.Domain.Interfaces;
using MediatR;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;
        public InspectionCommandHandler(IInspectionRepository inspectionRepository, IMapper mapper, IUserContext userContext)
        {
            _inspectionRepository = inspectionRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateInspectionCommand request, CancellationToken cancellationToken)
        {
            var inspection = _mapper.Map<Domain.Entities.Inspection>(request);
            
            inspection.CreatedById = _userContext.GetCurrentUser().Id;

            await _inspectionRepository.Create(inspection);
            return Unit.Value;
        }
    }
}
