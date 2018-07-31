using AirportUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWP.Interfaces
{
    public interface IAircraft
    {
        Task<IEnumerable<Aircraft>> Get();
        Task<bool> Delete(int id);
        Task<bool> Update(Aircraft aircraft);
        Task<bool> Create(Aircraft aircraft);
    }
}
