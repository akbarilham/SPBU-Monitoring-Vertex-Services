using SPBUMonitoringServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SPBUMonitoringServices.Contexts {

    public class EdcConfigContext : DbContext {

        public EdcConfigContext(DbContextOptions<EdcConfigContext> options)
            :base(options) { }
        public EdcConfigContext(){ }
        public DbSet<Printer> printers { get; set; }
        public DbSet<Tank> tanks { get; set; }
        public DbSet<Pump> pumps { get; set; }

    }
}
