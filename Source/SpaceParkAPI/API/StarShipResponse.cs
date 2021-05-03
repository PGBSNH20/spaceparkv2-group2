using System.Collections.Generic;

namespace SpaceParkAPI
{

    public class StarShip
    {
        public string Name { get; set; }
        public string Length { get; set; }
    }
    public class StarShipResponse
    {
        public List<StarShip> Results { get; set; }
    }
}