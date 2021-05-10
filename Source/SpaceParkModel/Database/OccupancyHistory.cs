using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceParkModel.Database
{
    public class OccupancyHistory
    {
        public string PersonName { get; set; }
        public string SpaceshipName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal AmountPaid { get; set; }
        public string SpaceParkName { get; set; }
    }
}
