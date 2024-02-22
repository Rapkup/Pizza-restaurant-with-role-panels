using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WEBKITTER.UI.Models;

namespace WEBKITTER.UI.Controllers
{
    public class OrdersController : Controller
    {
        private IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<string> GetOrders()
        {
            var orders = orderService.GetAll();
            return Json(orders);
        }


        [HttpPost("Orders/Add")]

        public ActionResult<string> Create([FromBody] OrderDTO order)
        {
            try
            {
                orderService.Create(order);
                return Ok("Заказ успешно добавлено");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Не получилось добавить клиента: {ex.Message}");
            }
        }


     /*   //Edit correct
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var order = orderService.Get(id);
                if (order != null)
                {
                    var OrderViewModel = new OrderModel()
                    {
                        Id = order.DishID,
                        OrderDate = order.OrderDate,
                        OrderStatus = order.OrderStatus,
                        CustomerId = order.CustomerId,
                        DishId = order.DishID
                    };
                    return View(OrderViewModel);
                }
                else
                {
                    TempData["errorMessage"] = " Order details not avaible with the Id: {id}";
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
        public IActionResult Edit(OrderModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var order = new OrderDTO()
                    {
                        OrderID = model.Id,
                        OrderDate = model.OrderDate,
                        OrderStatus = model.OrderStatus,
                        CustomerId = model.CustomerId,
                        DishID = model.DishId
                    };
                    orderService.Update(order);
                    TempData["successMessage"] = " Order details updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = " Order data is invalid";
                    return View();

                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }*/

        [HttpDelete("Orders/Delete/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {            
                orderService.Delete(id);
                return Ok("Show deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting show: {ex.Message}");
            }
        }

        [HttpPut("Orders/Update/{id}")]

        public ActionResult<string> UpdateMenu(int id, [FromBody] OrderDTO order)
        {
            try
            {
                orderService.Update(order);

                return Ok("Seat updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating seat: {ex.Message}");
            }
        }
    }
}
