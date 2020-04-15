using SPBUMonitoringServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Interfaces {

    public interface IPushConfigs {
        Task<IEnumerable<Printer>> GetAll();
        Task InsertPrinter(string site_id, dynamic[] printer);
        Task InsertTank(string site_id, dynamic[] tank);
        Task InsertPump(string site_id, dynamic[] pump);
    }

}
