using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Domain.Entities
{
    public class BeehiveDetails
    {
        [Required(ErrorMessage = "Id ula jest wymagane")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Id ula musi być liczbą i nie może zawierać liter")]
        public required int Id { get; set; }
        [StringLength(20, MinimumLength =4)]
        public string BeehiveType { get; set; }
        public string QueenType { get; set; }
        public DateTime? LastInspection { get; set; }

    }
}
