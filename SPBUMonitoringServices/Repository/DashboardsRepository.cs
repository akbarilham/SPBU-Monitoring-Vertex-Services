using System.Collections.Generic;
using System.Linq;
using SPBUMonitoringServices.Models;
using SPBUMonitoringServices.Contexts;
using SPBUMonitoringServices.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SPBUMonitoringServices.Repository {

    public class DashboardsRepository : IDashboardsRepository {

        DasboardsContext _context;
        public DashboardsRepository(DasboardsContext context) {
            _context = context;
        }       

        public async Task Add(Dashboards item) {            
            await _context.Dashboards.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dashboards>> GetAll() {
            return await _context.Dashboards.ToListAsync();
        }

        public bool CheckValidUserKey(string reqkey) {
            var userkeyList = new List<string> {
                "28236d8ec201df516d0f6472d516d72d",
                "38236d8ec201df516d0f6472d516d72c",
                "48236d8ec201df516d0f6472d516d72b"
            };

            if (userkeyList.Contains(reqkey)) {
                return true;
            } else {
                return false;
            }
        }

        public async Task<Dashboards> Find(string key) {
            return await _context.Dashboards
                .Where(e => e.SPBUCode.Equals(key))
                .SingleOrDefaultAsync();
        }

        public async Task Update(Dashboards item) {
            var itemToUpdate = await _context.Dashboards.SingleOrDefaultAsync(r => r.SPBUCode == item.SPBUCode);
            if (itemToUpdate != null) {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Value = item.Value;
                itemToUpdate.LastReadingTime = item.LastReadingTime;
                itemToUpdate.Status = item.Status;
                //itemToUpdate.UpdatedAt = item.UpdatedAt;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Remove(string key) {
            var itemToRemove = await _context.Dashboards.SingleOrDefaultAsync(r => r.SPBUCode == key);
            if (itemToRemove != null) {
                _context.Dashboards.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

    }
}