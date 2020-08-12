using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Services
{
    public interface IDataService<T>
    {
        Task<T> Get(string uri, int id, object body = null);
        Task<ICollection<T>> GetAll(string uri, object body = null);
        Task<T> Put(string uri, int id, object body = null);
        Task<T> Post(string uri, int id, object body);
    }
}
