using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SPBUMonitoringServices.Interfaces;
using SPBUMonitoringServices.Models.Responses;

namespace SPBUMonitoringServices.Controllers {

    [Route("api/edc-status")]
    public class EdcStatusController : Controller {

        public IEdcStatus EdcStatusRepo { get; set; }

        public EdcStatusController(IEdcStatus _repo) {
            EdcStatusRepo = _repo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() {
            var notFoundResponse = new { status = 404, message = "NOT FOUND: Data is not found" };
            try {
                var dashboardList = await EdcStatusRepo.GetAll();
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
        public async Task<IActionResult> Create([FromBody] EdcStatus item) {
            var badRequestResponse = new { status = 404, message = "BAD REQUEST: data isn't match" };
            var successResponse = new { status = 200, message = "Insert data is successfully" };
            try {
                if (item == null) {
                    return Json(badRequestResponse);
                }
                await EdcStatusRepo.Insert(item);
                return Json(successResponse);
            } catch (Exception ex) {
                Debug.WriteLine("Insert Data Exception: " + ex.Message);
                throw;
            }
        }

    }
}