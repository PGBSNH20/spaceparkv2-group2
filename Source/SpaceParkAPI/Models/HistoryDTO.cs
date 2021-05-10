using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Models
{
    public class HistoryDTO
    {
        public string PersonName { get; set; }
        public string SpaceshipName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal AmountPaid { get; set; }
        public string SpaceParkName { get; set; }
    }
}
