using SPBUMonitoringServices.Models;
using SPBUMonitoringServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Controllers {

    [Route("api/[controller]")]
    public class EdcsController : Controller {

        public IEdcs EdcsRepo { get; set; }

        public EdcsController(IEdcs _repo) {
            EdcsRepo = _repo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() {
            var notFoundResponse = new { status = 404, message = "NOT FOUND: Data is not found" };
            try {
                var dashboardList = await EdcsRepo.GetAll();
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
        public async Task<IActionResult> Create([FromBody] Edcs item) {
            var badRequestResponse = new { status = 404, message = "BAD REQUEST: data isn't match" };
            var successResponse = new { status = 200, message = "Insert data is successfully" };
            try {
                if (item == null) {
                    return Json(badRequestResponse);
                }
                await EdcsRepo.Add(item);
                return Json(successResponse);
            } catch (Exception ex) {
                Debug.WriteLine("Insert Data Exception: " + ex.Message);
                throw;
            }
        }

    }
}