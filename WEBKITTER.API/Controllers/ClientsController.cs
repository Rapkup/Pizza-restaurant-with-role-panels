using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL.DTO;

namespace WEBKITTER.API.Controllers
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


/*
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var customer = customerService.Get(id);
                if (customer != null)
                {
                    var customerView = new ClientModel()
                    {
                        Id = customer.Id,
                        FirstName = customer.Name,
                        LastName = customer.LastName,
                        Adderess = customer.Address,
                        PhonrNumber = customer.PhoneNumber,
                    };
                    return View(customerView);
                }
                else
                {
                    TempData["errorMessage"] = " Dish details not avaible with the Id: {id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(ClientModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = new ClientDTO()
                    {
                        Id = model.Id,
                        Name = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Adderess,
                        PhoneNumber = model.PhonrNumber,
                    };
                    customerService.Update(customer);
                    TempData["successMessage"] = " Dish details updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = " Dish data is invalid";
                    return View();

                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();

            }
        }
*/

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

        /*[HttpGet]
         *[Authorize (Roles ="admin, ClManager")]

        public IActionResult Search(string name)
        {
            var customers = customerService.SearchDish(name);
            List<CustomerViewModel> custlist = new List<CustomerViewModel>();
            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    var CustomerViewModel = new CustomerViewModel()
                    {
                        Id = customer.CustomerId,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Adderess = customer.Address,
                        PhonrNumber = customer.PhoneNumber,
                    };
                    custlist.Add(CustomerViewModel);
                }
            }
            return View("Index", custlist);
        }*/

    }
}
