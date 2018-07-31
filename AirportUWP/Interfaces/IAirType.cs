using AirportUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWP.Services
{
    public interface IAirType
    {
        Task<IEnumerable<AirType>> Get();
        Task<bool> Delete(int id);
        Task<bool> Update(AirType airtype);
        Task<bool> Create(AirType airtype);
    }
}
