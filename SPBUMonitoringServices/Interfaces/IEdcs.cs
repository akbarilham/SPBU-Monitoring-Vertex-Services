using SPBUMonitoringServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Interfaces {

    public interface IEdcs {
        Task Add(Edcs item);
        Task<IEnumerable<Edcs>> GetAll();
        Task<Edcs> Find(string key);
    }

}
