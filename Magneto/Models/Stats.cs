using System.ComponentModel;

namespace Magneto.Models
{
    public class Stats
    {
        [DisplayName("Total Humans: ")]
        public int TotalHumans { get; set; }
        [DisplayName("Total Mutants: ")]
        public  int TotalMutants { get; set; }
        [DisplayName("Ratio: ")]
        public double Ratio { get; set; }
    }
}
