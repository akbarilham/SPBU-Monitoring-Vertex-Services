using System.Collections.Generic;
using System.Linq;
using SPBUMonitoringServices.Models;
using SPBUMonitoringServices.Contexts;
using SPBUMonitoringServices.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SPBUMonitoringServices.Repository {

    public class EdcsRepository : IEdcs {

        EdcsContext _context;
        public EdcsRepository(EdcsContext context) {
            _context = context;
        }       

        public async Task<IEnumerable<Edcs>> GetAll() {
            return await _context.Edcs.ToListAsync();
        }

        public async Task<Edcs> Find(string key) {
            return await _context.Edcs
                .Where(e => e.site_id.Equals(key))
                .SingleOrDefaultAsync();
        }

        public async Task Add(Edcs item) {
            await _context.Edcs.AddAsync(item);
            await _context.SaveChangesAsync();
        }

    }
}