using SPBUMonitoringServices.Models;
using SPBUMonitoringServices.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SPBUMonitoringServices.Interfaces;

namespace SPBUMonitoringServices.Controllers {

    [Route("api/[controller]")]
    public class DashboardsController : Controller {

        public IDashboardsRepository DashboardsRepo { get; set; }

        public DashboardsController(IDashboardsRepository _repo) {
            DashboardsRepo = _repo;
        }
        
        [HttpGet("all", Name = "GetAllDashboard")]
        public async Task<IActionResult> GetAll() {
            var notFoundResponse = new { status = 404, message = "NOT FOUND: Data is not found"};
            try {
                var dashboardList = await DashboardsRepo.GetAll();
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

        [HttpGet("{id}", Name = "GetSPBUCode")]
        public async Task<IActionResult> GetById(string id) {
            var notFoundResponse = new { status = 404, message = "NOT FOUND: Data is not found" };
            var successResponse = new { status = 200, message = "Get data by Id is successfullly" };
            try {
                var item = await DashboardsRepo.Find(id);
                if (item == null) {
                    return Json(notFoundResponse);
                }
                return Json(successResponse);
            } catch (Exception ex ){
                Debug.WriteLine("Get by Id Exception: " + ex.Message);
                throw;
            }
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Create([FromBody] Dashboards item) {
            var badRequestResponse = new { status = 404, message = "BAD REQUEST: " };
            var successResponse = new { status = 200, message = "Insert data is successfully" };
            try {
                if (item == null) {
                    return Json(badRequestResponse);
                }
                await DashboardsRepo.Add(item);
                return Json(successResponse);
            } catch (Exception ex) {
                Debug.WriteLine("Insert Data Exception: " + ex.Message);
                throw;
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Dashboards item) {
            var notFoundResponse = new { status = 404, message = "NOT FOUND: Data is not found" };
            var badRequestResponse = new { status = 404, message = "BAD REQUEST: " };
            var successResponse = new { status = 200, message = "Update data is successfully" };
            try {
                if (item == null) {
                    return Json(badRequestResponse);
                }
                var dashboardObj = await DashboardsRepo.Find(item.SPBUCode);
                if (dashboardObj == null) {
                    return Json(notFoundResponse);
                }
                await DashboardsRepo.Update(item);
                return Json(successResponse);
            } catch (Exception ex) {
                Debug.WriteLine("Update Data Exception: " + ex.Message);
                throw;
            }

        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] Dashboards item) {
            var notFoundResponse = new { status = 404, message = "NOT FOUND: Data is not found" };
            var successResponse = new { status = 200, message = "Delete data is successfully" };
            try {
                var dashboardObj = await DashboardsRepo.Find(item.SPBUCode);
                if (dashboardObj == null) {
                    return Json(notFoundResponse);
                }
                await DashboardsRepo.Remove(item.SPBUCode);
                return Json(successResponse);
            } catch (Exception ex) {
                Debug.WriteLine("Delete Data Exception: " + ex.Message);
                throw;
            }
        }

    }
}