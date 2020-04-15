using SPBUMonitoringServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Repository {

    public interface IDashboardsRepository {
        Task Add(Dashboards item);
        Task<IEnumerable<Dashboards>> GetAll();
        Task<Dashboards> Find(string key);
        Task Remove(string Id);
        Task Update(Dashboards item);
        bool CheckValidUserKey(string reqkey);
    }

}
