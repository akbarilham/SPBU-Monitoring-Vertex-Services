using SPBUMonitoringServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SPBUMonitoringServices.Contexts {

    public class PushConfigsContext : DbContext {

        public PushConfigsContext(DbContextOptions<PushConfigsContext> options)
            :base(options) { }
        public PushConfigsContext(){ }
        public DbSet<Printer> printers { get; set; }
        public DbSet<Tank> tanks { get; set; }
        public DbSet<Pump> pumps { get; set; }

    }
}
