using SPBUMonitoringServices.Models;
using Microsoft.EntityFrameworkCore;

namespace SPBUMonitoringServices.Contexts {

    public class DasboardsContext : DbContext {

        public DasboardsContext(DbContextOptions<DasboardsContext> options)
            :base(options) { }
        public DasboardsContext(){ }
        public DbSet<Dashboards> Dashboards { get; set; }

    }
}
