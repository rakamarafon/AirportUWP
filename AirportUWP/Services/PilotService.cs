using AirportUWP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace AirportUWP.Services
{
    public class PilotService : IPilot
    {
        private string URL = "http://localhost:5000/api/Pilots";

        public async Task<IEnumerable<Pilot>> Get()
        {
            string responceString;
            using (var client = new HttpClient())
            {
                try
                {
                   responceString = await client.GetStringAsync(URL);
                }
                catch (Exception e)
                {
                   return null;
                }
            }

            var json = JsonConvert.DeserializeObject<IEnumerable<Pilot>>(responceString);

            return json;
        }
    }
}
