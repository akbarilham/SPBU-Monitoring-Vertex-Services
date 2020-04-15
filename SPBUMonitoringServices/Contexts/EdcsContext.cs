using SPBUMonitoringServices.Models;
using Microsoft.EntityFrameworkCore;

namespace SPBUMonitoringServices.Contexts {

    public class EdcsContext : DbContext {

        public EdcsContext(DbContextOptions<EdcsContext> options)
            :base(options) { }
        public EdcsContext(){ }
        public DbSet<Edcs> Edcs { get; set; }

    }
}
