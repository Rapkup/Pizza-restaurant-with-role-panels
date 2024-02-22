using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEBKITTER.UI.Models;

namespace WEBKITTER.UI.Controllers
{
    public class ClientsController : Controller
    {

        private ICustomerService customerService;

        public ClientsController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = customerService.GetAll();
            return Json(clients);
        }


        [HttpPost("Clients/Add")]
        public ActionResult<string> Create([FromBody] ClientDTO client)
        {
            try
            {
                customerService.Create(client);
                return Ok("Клиент успешно добавлен");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Не получилось добавить клиента: {ex.Message}");
            }
        }

        [HttpDelete("Clients/Delete/{id}")]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                customerService.Delete(id);
                return Ok("Show deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting show: {ex.Message}");
            }
        }

        [HttpPut("Clients/Update/{id}")]
        public ActionResult<string> UpdateClient(int id, [FromBody] ClientDTO client)
        {
            try
            {
                customerService.Update(client);

                return Ok("Seat updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating seat: {ex.Message}");
            }
        }

      
    }
}
