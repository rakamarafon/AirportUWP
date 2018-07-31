using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AirportUWP.Models;
using Newtonsoft.Json;

namespace AirportUWP.Services
{
    public class AirTypeService : IAirType
    {
        private string URL = "http://localhost:5000/api/Airtypes";

        public async Task<bool> Create(AirType airtype)
        {
            string temp = JsonConvert.SerializeObject(airtype);
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

        public async Task<IEnumerable<AirType>> Get()
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

            var json = JsonConvert.DeserializeObject<IEnumerable<AirType>>(responceString);

            return json;
        }

        public async Task<bool> Update(AirType airtype)
        {
            string temp = JsonConvert.SerializeObject(airtype);
            var httpContent = new StringContent(temp, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var response = await client.PutAsync(string.Format("{0}/{1}", URL, airtype.Id), httpContent);
                if (response.IsSuccessStatusCode) return true;
                return false;
            }
        }
    }
}
