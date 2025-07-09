using Microsoft.AspNetCore.Mvc;
using UserInfoApp.Application.Services;
using UserInfoApp.Web.ViewModels;

namespace UserInfoApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login() => View(new LoginViewModel());

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (_authService.ValidateUser(model.Username, model.Password, out var person))
            {
                HttpContext.Session.SetInt32("UserId", person.Id);
                return RedirectToAction("Index", "Info");
            }
            model.ErrorMessage = "Invalid login.";
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
