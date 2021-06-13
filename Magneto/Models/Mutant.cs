using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Magneto.Models
{
    public class Mutant
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Input DNA string:")]
        public string DNA { get; set; }
        public bool IsMutant { get; set; }
    }
}
