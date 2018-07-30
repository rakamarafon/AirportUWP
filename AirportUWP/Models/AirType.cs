using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWP.Models
{
    public class AirType
    {
        public int Id { get; set; }
        public string Model { get; set; }

        public int SeatsNumber { get; set; }

        public int FlightDataModelId { get; set; }
    }
}
