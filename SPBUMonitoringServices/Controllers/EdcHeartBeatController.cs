using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SPBUMonitoringServices.Models;
using SPBUMonitoringServices.Interfaces;

namespace SPBUMonitoringServices.Controllers {

    [Route("api/edc-heart-beat")]
    public class EdcHeartBeatController : Controller {

        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public IEdcHeartBeat EdcHeartBeatRepo { get; set; }

        public EdcHeartBeatController(IEdcHeartBeat _repo) {
            EdcHeartBeatRepo = _repo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() {
            var heartBeatList = await EdcHeartBeatRepo.GetAll();
            if (heartBeatList == null) {
                return StatusCode(404, Json(new { message = "NOT FOUND: Data isn't found" }));
            }
            return StatusCode(200, Json(new { message = "Get all data are sucessfully", data = heartBeatList }));
        }

        [HttpGet("by-spbu-id/{spbuId}")]
        public async Task<IActionResult> GetBySpbuId(string spbuId) {
            var heartBeatList = await EdcHeartBeatRepo.GetBySpbuId(spbuId);
            if (heartBeatList == null) {
                return StatusCode(404, Json(new { message = "NOT FOUND: Data isn't found" }));
            }
            return StatusCode(200, Json(new { message = "Get SPBU ID data is sucessfully", data = heartBeatList }));
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Create([FromBody] EdcHeartBeat request) {
            Logger.Info("Heart Beat - Data Payload = " + request);
            if (request == null) {
                return StatusCode(500, Json(new { message = "INTERNAL SERVER ERROR: Data isn't match or one of data is null" }));
            }
            await EdcHeartBeatRepo.Insert(request);
            return StatusCode(201, Json(new { message = "Insert data is successfully" }));
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] EdcHeartBeat data) {
            Logger.Info("Heart Beat - Data Payload = " + data);
            if (data == null) {
                return StatusCode(500, Json(new { message = "INTERNAL SERVER ERROR: Data isn't match or one of data is null" }));
            }
            await EdcHeartBeatRepo.Update(data);
            return StatusCode(201, Json(new { message = "Update data is successfully" }));
        }

    }
}