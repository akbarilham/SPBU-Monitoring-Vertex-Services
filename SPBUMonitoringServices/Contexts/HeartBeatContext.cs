using SPBUMonitoringServices.Models;
using Microsoft.EntityFrameworkCore;

namespace SPBUMonitoringServices.Contexts {

    public class HeartBeatContext : DbContext {

        public HeartBeatContext(DbContextOptions<HeartBeatContext> options)
            :base(options) { }
        public HeartBeatContext(){ }
        public DbSet<HeartBeat> server_status { get; set; }

    }
}
