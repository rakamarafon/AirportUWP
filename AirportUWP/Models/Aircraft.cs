using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWP.Models
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AirTypeModelId { get; set; }

        public string ReleaseDate { get; set; }

        public string LifeTime { get; set; }
    }
}
