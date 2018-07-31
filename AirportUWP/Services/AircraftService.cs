using AirportUWP.Interfaces;
using AirportUWP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWP.Services
{
    public class AircraftService : IAircraft
    {
        private string URL = "http://localhost:5000/api/Aircrafts";

        public async Task<bool> Create(Aircraft aircraft)
        {
            string temp = JsonConvert.SerializeObject(aircraft);
            var httpContent = new StringContent(temp, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(URL, httpContent);
                if (response.IsSuccessStatusCode) return true;
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(string.Format("{0}/{1}", URL, id));
                if (response.IsSuccessStatusCode) return true;
                return false;
            }
        }

        public async Task<IEnumerable<Aircraft>> Get()
        {
            string responceString;
            using (var client = new HttpClient())
            {
                responceString = await client.GetStringAsync(URL);
            }
            var json = JsonConvert.DeserializeObject<IEnumerable<Aircraft>>(responceString);
            return json;
        }

        public async Task<bool> Update(Aircraft aircraft)
        {
            string temp = JsonConvert.SerializeObject(aircraft);
            var httpContent = new StringContent(temp, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var response = await client.PutAsync(string.Format("{0}/{1}", URL, aircraft.Id), httpContent);
                if (response.IsSuccessStatusCode) return true;
                return false;
            }
        }
    }
}
