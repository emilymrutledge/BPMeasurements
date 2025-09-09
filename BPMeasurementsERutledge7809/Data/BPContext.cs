using BPMeasurementsERutledge7809.Models;
using Microsoft.EntityFrameworkCore;

namespace BPMeasurementsERutledge7809.Data
{
    public class BPContext : DbContext
    {
        public BPContext(DbContextOptions<BPContext> options) : base(options) { }

        public DbSet<BPMeasurement> BPMeasurements { get; set; }

        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
                new Position { ID = "S", Name = "Sitting" },
                new Position { ID = "T", Name = "Standing" },
                new Position { ID = "L", Name = "Lying Down" }
                );

            modelBuilder.Entity<BPMeasurement>().HasData(
                new BPMeasurement { ID = 1, Systolic = 120, Diastolic = 80, MeasurementDate = new DateTime(2025, 06, 02), PositionID = "S" },
                new BPMeasurement { ID = 2, Systolic = 130, Diastolic = 85, MeasurementDate = new DateTime(2025, 06, 02), PositionID = "T" },
                new BPMeasurement { ID = 3, Systolic = 140, Diastolic = 90, MeasurementDate = new DateTime(2025, 06, 02), PositionID = "L" },
                new BPMeasurement { ID = 4, Systolic = 160, Diastolic = 100, MeasurementDate = new DateTime(2025, 06, 02), PositionID = "S" },
                new BPMeasurement { ID = 5, Systolic = 180, Diastolic = 110, MeasurementDate = new DateTime(2025, 06, 02), PositionID = "T" }
            );
        }
    }
}
