using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceParkModel.Database
{
    public class Occupancy
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [ForeignKey("Person")]
        public int PersonID { get; set; }
        [Required]
        [ForeignKey("Spaceship")]
        public int SpaceshipID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DepartureTime { get; set; }
        [Required]
        [ForeignKey("ParkingSpots")]
        public int ParkingSpotID { get; set; }
        [Required]
        [ForeignKey("SpacePark")]
        public int SpaceParkID { get; set; }
    }
}
