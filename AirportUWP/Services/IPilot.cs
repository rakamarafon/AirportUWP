using AirportUWP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirportUWP.Services
{
    public interface IPilot
    {
        Task<IEnumerable<Pilot>> Get();
        Task<bool> Delete(int id);
        Task<bool> Update(Pilot pilot);
        Task<bool> Create(Pilot pilot);
    }
}
