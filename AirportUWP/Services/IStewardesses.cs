using AirportUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWP.Services
{
    public interface IStewardesses
    {
        Task<IEnumerable<Stewardesses>> Get();
        Task<bool> Delete(int id);
        Task<bool> Update(Stewardesses stewardesses);
        Task<bool> Create(Stewardesses stewardesses);
    }
}
