using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPMeasurementsERutledge7809.Models
{
    public class BPMeasurement
    {
        public int ID { get; set; }

        [Required]
        [Range(20,400)]
        public int Systolic {  get; set; }

        [Required]
        [Range(10, 300)]
        public int Diastolic { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime MeasurementDate { get; set; }

        [Required]
        public required string PositionID { get; set; }

        public Position? Position { get; set; }

        [NotMapped]
        public string Category
        {
            get
            {
                if (Systolic >= 180 || Diastolic >= 120) return "Hypertensive Crisis";
                if (Systolic >= 140 || Diastolic >= 90) return "Hypertension Stage 2";
                if (Systolic >= 130 || Diastolic >= 80) return "Hypertension Stage 1";
                if (Systolic >= 120 && Diastolic < 80) return "Elevated";
                return "Normal";
            }
        }

    }
}
