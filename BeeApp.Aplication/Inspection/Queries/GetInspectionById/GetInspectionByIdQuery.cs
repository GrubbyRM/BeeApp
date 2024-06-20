using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Aplication.Inspection.Queries.GetInspectionById
{
    public class GetInspectionByIdQuery : IRequest<Domain.Entities.Inspection>
    {
        public int InspectionId { get; set; }

        public GetInspectionByIdQuery(int inspectionId)
        {
            InspectionId = inspectionId;
        }
    }
}
