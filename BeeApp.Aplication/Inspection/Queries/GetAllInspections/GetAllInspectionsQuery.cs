using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Aplication.Inspection.Queries.GetAllInspections
{
    public class GetAllInspectionsQuery : IRequest<IEnumerable<Domain.Entities.Inspection>>
    {
    }
}
