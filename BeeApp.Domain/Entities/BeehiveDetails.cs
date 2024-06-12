using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Domain.Entities
{
    public class BeehiveDetails
    {
        public required int Id { get; set; }
        public string BeehiveType { get; set; }
        public string QueenType { get; set; }
        public DateTime? LastInspection { get; set; }

    }
}
