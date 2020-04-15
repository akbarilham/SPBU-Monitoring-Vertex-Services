using System.Threading.Tasks;
using System.Collections.Generic;
using SPBUMonitoringServices.Models.Responses;

namespace SPBUMonitoringServices.Interfaces {

    public interface IEdcStatus {
        Task<IEnumerable<EdcStatus>> GetAll();
        Task<IEnumerable<EdcStatus>> GetBySpbuId(string spbuId);
        Task Insert(EdcStatus item);
        Task Update(EdcStatus item);
        // kondisi update, jika tidak ada SPBU ID, harus create atau insert
    }

}
