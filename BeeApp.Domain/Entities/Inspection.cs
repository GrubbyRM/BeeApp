using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Domain.Entities
{
    public class Inspection
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool QueenBee { get; set; }
        public bool BeeBrood { get; set; }
        public bool Eggs { get; set; }
        public bool Feed { get; set; }
        public bool QueenCell { get; set; }
        
        public bool BeeBread { get; set; }
        public string? Notes { get; set; }
        public BeehiveDetails BeehiveDetails { get; set; } = default!;

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

    }
}
