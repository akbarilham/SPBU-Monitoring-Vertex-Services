using SPBUMonitoringServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Interfaces {

    public interface IEdcConfig {
        Task<IEnumerable<Printer>> GetAll();
        //Task<IEnumerable<Printer>> GetBySpbuId(int spbuId);
        Task InsertPrinter(int site_id, dynamic[] printer);
        Task InsertTank(int site_id, dynamic[] tank);
        Task InsertPump(int site_id, dynamic[] pump);
    }

}
