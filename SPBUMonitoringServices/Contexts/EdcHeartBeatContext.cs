using SPBUMonitoringServices.Models;
using Microsoft.EntityFrameworkCore;

namespace SPBUMonitoringServices.Contexts {

    public class EdcHeartBeatContext : DbContext {

        public EdcHeartBeatContext(DbContextOptions<EdcHeartBeatContext> options)
            :base(options) { }
        public EdcHeartBeatContext(){ }
        public DbSet<EdcHeartBeat> server_status { get; set; }

    }
}
