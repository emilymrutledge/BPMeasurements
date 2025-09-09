using System.ComponentModel.DataAnnotations;

namespace BPMeasurementsERutledge7809.Models
{
    public class Position
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
