using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SPBUMonitoringServices.Models;
using SPBUMonitoringServices.Interfaces;

namespace SPBUMonitoringServices.Controllers {

    [Route("api/edc-config")]
    public class EdcConfigController : Controller {

        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public IEdcConfig PushConfigsRepo { get; set; }

        public EdcConfigController(IEdcConfig _repo) {
            PushConfigsRepo = _repo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() {
            var pushConfigsList = await PushConfigsRepo.GetAll();
            if (pushConfigsList == null) {
                return Json(new { message = "NOT FOUND: Data is not found" });
            }
            return Json(new { message = "Get all data are sucessfully", data = pushConfigsList });
        }
        /*
        [HttpGet("by-spbu-id/{spbuId}")]
        public async Task<IActionResult> GetBySpbuId(string spbuId) {
            var heartBeatList = await PushConfigsRepo.GetBySpbuId(spbuId);
            if (heartBeatList == null) {
                return StatusCode(404, Json(new { message = "NOT FOUND: Data isn't found" }));
            }
            return StatusCode(200, Json(new { message = "Get SPBU ID data is sucessfully", data = heartBeatList }));
        }
        */
        [HttpPost("insert")]
        public async Task<IActionResult> Create([FromBody] EdcConfig request) {
            Logger.Info("EDC Config - Data Payload = " + request);
            if (request == null) {
                return Json(new { message = "BAD REQUEST: data isn't match"});
            }
            await PushConfigsRepo.InsertPrinter(request.site_id, request.printer);
            await PushConfigsRepo.InsertTank(request.site_id, request.tank);
            await PushConfigsRepo.InsertPump(request.site_id, request.pump);
            return Json(new { message = "Insert push config is successfully" });
        }

    }
}