using AirportUWP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirportUWP.Services
{
    public interface IPilot
    {
        Task<IEnumerable<Pilot>> Get();
    }
}
