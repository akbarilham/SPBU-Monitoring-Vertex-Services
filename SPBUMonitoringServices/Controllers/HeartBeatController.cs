using SPBUMonitoringServices.Models;
using SPBUMonitoringServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SPBUMonitoringServices.Controllers {

    [Route("api/server-status")]
    public class HeartBeatController : Controller {

        public IHeartBeat HeartBeatRepo { get; set; }

        public HeartBeatController(IHeartBeat _repo) {
            HeartBeatRepo = _repo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() {
            try {
                var heartBeatList = await HeartBeatRepo.GetAll();
                if (heartBeatList == null) {
                    return StatusCode(404, Json(new { message = "NOT FOUND: Data isn't found" }));
                }
                return StatusCode(200, Json(new { message = "Get all data are sucessfully", data = heartBeatList }));
            } catch (Exception ex) {
                Debug.WriteLine("Get All Exception: " + ex.Message);
                throw;
            }
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Create([FromBody] HeartBeat data) {
            try {
                if (data == null) {
                    return StatusCode(500, Json(new { message = "INTERNAL SERVER ERROR: Data isn't match or one of data null" }));
                }
                await HeartBeatRepo.Add(data);
                return StatusCode(201, Json(new { message = "Insert data is successfully" }));
            } catch (Exception ex) {
                Debug.WriteLine("Insert Data Exception: " + ex.Message);
                throw;
            }
        }

    }
}