using System.Collections.Generic;
using System.Linq;
using SPBUMonitoringServices.Models.Responses;
using SPBUMonitoringServices.Contexts;
using SPBUMonitoringServices.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace SPBUMonitoringServices.Repository {

    public class EdcStatusRepository : IEdcStatus {

        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        EdcStatusContext _context;

        public EdcStatusRepository(EdcStatusContext context) {
            _context = context;
        }       

        public async Task<IEnumerable<EdcStatus>> GetAll() {
            return await _context.EdcStatus
                .ToListAsync();
        }

        public async Task<IEnumerable<EdcStatus>> GetBySpbuId(string spbuId) {
            return await _context.EdcStatus
                .Where(c => c.site_id == spbuId)
                .ToListAsync();
        }

        public async Task Insert(EdcStatus data) {
            if (data != null) {
                try {
                    Logger.Info("EDC Status - data to insert = " + data);

                    await _context.EdcStatus.AddAsync(data);
                    await _context.SaveChangesAsync();
                    Logger.Info("EDC Status insert successfully");
                } catch (Exception ex) {
                    Debug.WriteLine("Insert EDC Status Exception: " + ex.Message);
                    throw;
                }
            }
        }

        public async Task Update(EdcStatus data) {
            if (data != null) {
                try {
                    var dataToUpdate = new EdcStatus();
                    dataToUpdate.site_id = data.site_id;
                    Logger.Info("EDC Status - data to update = " + dataToUpdate);

                    await _context.EdcStatus.SingleOrDefaultAsync(r => r.site_id == data.site_id);
                    await _context.SaveChangesAsync();
                    Logger.Info("EDC Status update successfully");
                } catch (Exception ex) {
                    Debug.WriteLine("Update EDC Status Exception: " + ex.Message);
                    throw;
                }
            }
        }

    }
}