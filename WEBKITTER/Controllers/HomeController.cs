using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEBKITTER.Models;

namespace WEBKITTER.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {



        [Authorize(Roles = "Administrator")]
        public IActionResult AdminPanel()
        {
            return View();
        }

        [Authorize(Roles = "Client")]
        [AllowAnonymous]
        public IActionResult Client()
        {
            return View();
        }

        [Authorize(Roles = "ClientManager")]
        [AllowAnonymous]
        public IActionResult ManagerClient()
        {
            return View();
        }



        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


     


        [AllowAnonymous]
        [HttpGet("/Account/Login")]
        public IActionResult AccessDeniedLogin()
        {
            return RedirectToAction("Login", "Home");
        }

        [HttpGet("/Account/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}