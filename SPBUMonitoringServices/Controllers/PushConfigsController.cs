using SPBUMonitoringServices.Models;
using SPBUMonitoringServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SPBUMonitoringServices.Controllers {

    [Route("api/push-config")]
    public class PushConfigsController : Controller {

        public IPushConfigs PushConfigsRepo { get; set; }
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public PushConfigsController(IPushConfigs _repo) {
            PushConfigsRepo = _repo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() {
            var notFoundResponse = new { status = 404, message = "NOT FOUND: Data is not found" };
            try {
                var dashboardList = await PushConfigsRepo.GetAll();
                var successResponse = new { status = 200, message = "Get all data are sucessfully", data = dashboardList };
                if (dashboardList == null) {
                    return Json(notFoundResponse);
                }
                return Json(successResponse);
            } catch (Exception ex) {
                Debug.WriteLine("Get All Exception: " + ex.Message);
                throw;
            }
        }
        
        [HttpPost("insert")]
        public async Task<IActionResult> Create([FromBody] PushConfigs request) {

            try {
                if (request == null) {
                    return Json(new { message = "BAD REQUEST: data isn't match"});
                }
                await PushConfigsRepo.InsertPrinter(request.site_id, request.printer);
                await PushConfigsRepo.InsertTank(request.site_id, request.tank);
                await PushConfigsRepo.InsertPump(request.site_id, request.pump);
                return Json(new { message = "Insert push config is successfully" });
            } catch (Exception ex) {
                Debug.WriteLine("Insert PushConfig Exception: " + ex.Message);
                throw;
            }
        }

    }
}