using SPBUMonitoringServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Interfaces {

    public interface IEdcHeartBeat {
        Task<IEnumerable<EdcHeartBeat>> GetAll();
        Task<IEnumerable<EdcHeartBeat>> GetBySpbuId(string spbuId);
        Task Insert(EdcHeartBeat data);
        Task Update(EdcHeartBeat data);
    }

}
