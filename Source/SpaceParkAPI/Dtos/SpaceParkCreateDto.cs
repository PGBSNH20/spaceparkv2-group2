using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Dtos
{
    public class SpaceParkCreateDto
    {
        public int ID { get; set; }
        public int MinSize { get; set; }
        public int MaxSize { get; set; }
        public string CharacterName { get; set; }
        public string SpaceshipName { get; set; }
        public DateTime Arrival { get; set; }
    }
}
