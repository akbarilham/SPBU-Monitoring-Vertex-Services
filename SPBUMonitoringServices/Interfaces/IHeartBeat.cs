using SPBUMonitoringServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Interfaces {

    public interface IHeartBeat {
        Task<IEnumerable<HeartBeat>> GetAll();
        Task Add(HeartBeat data);
        Task Update(HeartBeat data);
    }

}
