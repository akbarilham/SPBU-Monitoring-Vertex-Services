using SPBUMonitoringServices.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace SPBUMonitoringServices.Contexts {

    public class EdcStatusContext : DbContext {

        public EdcStatusContext(DbContextOptions<EdcStatusContext> options)
            :base(options) { }
        public EdcStatusContext(){ }
        public DbSet<EdcStatus> EdcStatus { get; set; }

    }
}
