using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWP.Models
{
    public class Pilot
    {
        public int Id { get; set; }
        public int CrewModelId { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string FullName => $"{FirstName} {SecondName}";
        public string Birthday { set; get; }
        public int Experience { set; get; }
    }
}
