using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SPBUMonitoringServices.Models;
using SPBUMonitoringServices.Contexts;
using SPBUMonitoringServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace SPBUMonitoringServices.Repository {

    public class EdcHeartBeatRepository : IEdcHeartBeat {

        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        EdcHeartBeatContext _context;

        public EdcHeartBeatRepository(EdcHeartBeatContext context) {
            _context = context;
        }       

        public async Task<IEnumerable<EdcHeartBeat>> GetAll() {
            return await _context.server_status
                .OrderByDescending(a => a.Id)
                .Take(1)
                .ToListAsync();
        }

        public async Task<IEnumerable<EdcHeartBeat>> GetBySpbuId(string spbuId) {
            return await _context.server_status
                .OrderByDescending(a => a.Id)
                .Where(c => c.site_id == spbuId)
                .Take(1)
                .ToListAsync();
        }

        public async Task Insert(EdcHeartBeat data) {
            if (data != null) {
                try {
                    string now = DateTime.Now.ToString("s") + "Z";
                    DateTime tanggalNow = DateTime.Parse(now);

                    var dataToInsert = new EdcHeartBeat();
                    dataToInsert.site_id = data.site_id;
                    dataToInsert.app_datetime = data.app_datetime;
                    dataToInsert.server_datetime = tanggalNow;
                    Logger.Info("Heart Beat - data to insert = " + dataToInsert);

                    await _context.server_status.AddAsync(dataToInsert);
                    await _context.SaveChangesAsync();
                    Logger.Info("Heart Beat insert successfully");
                } catch (Exception ex) {
                    Debug.WriteLine("Insert Data Exception: " + ex.Message);
                    throw;
                }
            }
        }

        public async Task Update(EdcHeartBeat data) {
            if (data != null) {
                try {
                    string now = DateTime.Now.ToString("s") + "Z";
                    DateTime tanggalNow = DateTime.Parse(now);

                    var dataToUpdate = new EdcHeartBeat();
                    dataToUpdate.site_id = data.site_id;
                    dataToUpdate.app_datetime = data.app_datetime;
                    dataToUpdate.server_datetime = tanggalNow;
                    Logger.Info("Heart Beat - data to update = " + dataToUpdate);

                    await _context.server_status.SingleOrDefaultAsync(r => r.site_id == data.site_id);
                    await _context.SaveChangesAsync();
                    Logger.Info("Heart Beat update successfully");
                } catch (Exception ex) {
                    Debug.WriteLine("Update Data Exception: " + ex.Message);
                    throw;
                }
            }
        }

    }
}