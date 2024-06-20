using BeeApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Aplication.Inspection.Commands.EditInspection
{
    public class EditInspectionCommandHandler : IRequestHandler<EditInspectionCommand>
    {
        private readonly IInspectionRepository _inspectionRepository;
        public EditInspectionCommandHandler(IInspectionRepository inspectionRepository)
        {
            _inspectionRepository = inspectionRepository;
        }
        public async Task<Unit> Handle(EditInspectionCommand request, CancellationToken cancellationToken)
        {
            var inspection = await _inspectionRepository.GetById(request.Id);

            inspection.CreatedAt = request.CreatedAt;
            inspection.QueenBee = request.QueenBee;
            inspection.BeeBrood = request.BeeBrood;
            inspection.Eggs = request.Eggs;
            inspection.Feed = request.Feed;
            inspection.QueenCell = request.QueenCell;
            inspection.BeeBread = request.BeeBread;
            inspection.Notes = request.Notes;

            inspection.BeehiveDetails.Id = request.BeehiveDetails.Id;
            inspection.BeehiveDetails.BeehiveType = request.BeehiveDetails.BeehiveType;
            inspection.BeehiveDetails.QueenType = request.BeehiveDetails.QueenType;
            inspection.BeehiveDetails.LastInspection = request.BeehiveDetails.LastInspection;

            return Unit.Value;
        }
    }
}
