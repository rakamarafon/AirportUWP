using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWP.Models
{
    public class Departure
    {
        public string FlightNumber { get; set; }
        public string DepartureTime { get; set; }
        public int Crew { get; set; }
        public int Aircraft { get; set; }
    }
}
