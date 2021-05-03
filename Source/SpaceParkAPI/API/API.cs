using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkAPI
{
    public class API
    {
        // Using the API search function to get the Character       

        private static readonly RestClient client = new RestClient("https://swapi.dev/api/");
        private static async Task<IRestResponse> GetPersonResponse(string name)
        {          
                var request = new RestRequest("people/?search=" + name, DataFormat.Json);
                var response = client.ExecuteAsync<PersonResponse>(request);
                return await response;            
        }

        private static async Task<IRestResponse> GetSpaceshipResponseByIndex(int number)
        {
            var request = new RestRequest("starships/" + number + "/", DataFormat.Json);
            var response = client.ExecuteAsync<StarShip>(request);
            return await response;
        }

        public static PersonData GetPerson(string name)
        {
            var dataResponse = GetPersonResponse(name);
            var data = JsonConvert.DeserializeObject<PersonResponse>(dataResponse.Result.Content);
            return data.Results[0];
        }

        public static StarShip GetSpaceShip(int number)
        {
            var dataResponse = GetSpaceshipResponseByIndex(number);
            var data = JsonConvert.DeserializeObject<StarShip>(dataResponse.Result.Content);

            return data;
        }
    }
}
