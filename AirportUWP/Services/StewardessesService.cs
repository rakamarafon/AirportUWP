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
    public class StewardessesService : IStewardesses
    {
        private string URL = "http://localhost:5000/api/Stewardesses";

        public async Task<bool> Create(Stewardesses stewardesses)
        {
            string temp = JsonConvert.SerializeObject(stewardesses);
            var httpContent = new StringContent(temp, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync( URL, httpContent);
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

        public async Task<IEnumerable<Stewardesses>> Get()
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

            var json = JsonConvert.DeserializeObject<IEnumerable<Stewardesses>>(responceString);

            return json;
        }

        public async Task<bool> Update(Stewardesses stewardesses)
        {
            string temp = JsonConvert.SerializeObject(stewardesses);
            var httpContent = new StringContent(temp, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var response = await client.PutAsync(string.Format("{0}/{1}", URL, stewardesses.Id), httpContent);
                if (response.IsSuccessStatusCode) return true;
                return false;
            }
        }
    }
}
