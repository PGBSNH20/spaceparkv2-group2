using System.Collections.Generic;

namespace SpaceParkAPI
{
    
        public class PersonData
        {


            public int PersonID { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string url { get; set; }
            public List<string> Starships { get; set; }
        }

        public class PersonResponse
        {
            public List<PersonData> Results { get; set; }

        }
    
}