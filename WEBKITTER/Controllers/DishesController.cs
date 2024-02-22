using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEBKITTER.UI.Models;

namespace WEBKITTER.UI.Controllers
{
    public class DishesController : Controller
    {
        private IDishService dishService;

        public DishesController(IDishService dishService)
        {
            this.dishService = dishService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<string> GetDishes()
        {
            var menus = dishService.GetAll();
            return Json(menus);
        }


        [HttpPost("Dishes/Add")]
        public ActionResult<string> Create([FromBody] DishDTO client)
        {
            try
            {
                dishService.Create(client);
                return Ok("Клиент успешно добавлен");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Не получилось добавить клиента: {ex.Message}");
            }
        }


        public IActionResult Edit(DishModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dish = new DishDTO()
                    {
                        DishID = model.Id,
                        DishName = model.Name,
                        Description = model.Description
                    };
                    dishService.Update(dish);
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

        [HttpDelete("Dishes/Delete/{id}")]
        public IActionResult DeleteDish(int id)
        {
            try
            {             
                dishService.Delete(id);
                return Ok("Show deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting show: {ex.Message}");
            }
        }

        [HttpPut("Dishes/Update/{id}")]
        public ActionResult<string> UpdateDish(int id, [FromBody] DishDTO client)
        {
            try
            {
                dishService.Update(client);

                return Ok("Seat updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating seat: {ex.Message}");
            }
        }
        
        /*
 * 
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            try
            {
                var dish = dishService.Get(id);
                if (dish != null)
                {
                    var dishView = new DishModel()
                    {
                        Id = dish.DishID,
                        Name = dish.DishName,
                        Description = dish.Description
                    };
                    return View(dishView);
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
        [Authorize(Roles = "admin")]
 * 
        [HttpGet]
        public IActionResult Search(string name)
        {
            var dishes = dishService.SearchDish(name);
            List<DishModel> dishlist = new List<DishModel>();
            if (dishes != null)
            {
                foreach (var dish in dishes)
                {
                    var DishViewModel = new DishModel()
                    {
                        Id = dish.DishID,
                        Name = dish.DishName,
                        Description = dish.Description
                    };
                    dishlist.Add(DishViewModel);
                }
            }
            return View("Index", dishlist);
        }*/
    }
}
