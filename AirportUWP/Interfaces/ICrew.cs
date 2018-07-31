using AirportUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWP.Services
{
    public interface ICrew
    {
        Task<IEnumerable<Crew>> Get();
        Task<bool> Delete(int id);
        Task<bool> Update(Crew crew);
        Task<bool> Create(Crew crew);
    }
}
