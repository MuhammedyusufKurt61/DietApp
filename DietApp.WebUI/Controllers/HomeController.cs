using DietApp.BLL.Abstract;
using DietApp.Entity;
using DietApp.Systm;
using DietApp.ViewModels.UserViewModels;
using DietApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Online2.Entity;
using System.Diagnostics;

namespace DietApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserBLL _userBLL;

        public HomeController(ILogger<HomeController> logger, IUserBLL userBLL)
        {
            _logger = logger;
            _userBLL = userBLL;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserLoginVM vm)
        {
            ResultService<User> user = _userBLL.Login(vm);
            if (user.HasError)
            {
                string errorMessage = user.ErrorItems.ToList()[0].ErrorMessage;
                string errorType = user.ErrorItems.ToList()[0].ErrorType;

                ViewData["ErrorMessage"] = errorMessage;
                ViewData["ErrorType"] = errorType;

                return View(vm);
            }

            string baseUrl = "https://localhost:7109";

            if (user.Data.UserTypes == UserTypes.Admin)
            {
                return Redirect($"{baseUrl}/Admin/Home/Index/{user.Data.Id}");
            }
            else
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}