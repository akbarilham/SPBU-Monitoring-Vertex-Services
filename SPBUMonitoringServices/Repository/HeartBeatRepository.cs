using System.Collections.Generic;
using System.Linq;
using SPBUMonitoringServices.Models;
using SPBUMonitoringServices.Contexts;
using SPBUMonitoringServices.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SPBUMonitoringServices.Repository {

    public class HeartBeatRepository : IHeartBeat {

        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        HeartBeatContext _context;

        public HeartBeatRepository(HeartBeatContext context) {
            _context = context;
        }       

        public async Task<IEnumerable<HeartBeat>> GetAll() {
            return await _context.server_status.OrderByDescending(a => a.Id).Take(1).ToListAsync();
        }

        public async Task Add(HeartBeat data) {
            string now = System.DateTime.Now.ToString("s") + "Z";
            //int index = listofelements.IndexOf(data);
            Logger.Info("Heart Beat Data = " + ObjectDumper.Dump(data));
            await _context.server_status.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task Update(HeartBeat data) {
            var dataToUpdate = await _context.server_status.SingleOrDefaultAsync(r => r.site_id == data.site_id);
            if (dataToUpdate != null) {
                dataToUpdate.app_datetime = data.app_datetime;
                dataToUpdate.server_datetime = data.server_datetime;
                await _context.SaveChangesAsync();
            }
        }

    }
}