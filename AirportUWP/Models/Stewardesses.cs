using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWP.Models
{
    public class Stewardesses
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FullName => $"{FirstName} {SecondName}";
        public string BirthDay { get; set; }
        public int CrewModelId { get; set; }
    }
}
