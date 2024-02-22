using Microsoft.AspNetCore.Mvc;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL.DTO;

namespace WEBKITTER.API.Controllers
{
    public class ApiController : Controller
    {
        private IDishService dishService;

         public ApiController(IDishService dishService)
        {
            this.dishService = dishService;
        }


        [HttpGet]
        public ActionResult<string> GetDishes()
        {
            var menus = dishService.GetAll();
            return Json(menus);
        }

    }
}
