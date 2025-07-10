using Microsoft.AspNetCore.Mvc;
using UserInfoApp.Application.Services;
using UserInfoApp.Domain.Entities;
using UserInfoApp.Web.ViewModels;

namespace UserInfoApp.Web.Controllers
{
    public class InfoController : Controller
    {
        private readonly IUserService _userService;

        public InfoController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var person = _userService.GetById(userId.Value);
            var model = new InfoViewModel
            {
                Name = person.Name,
                Surname = person.Surname,
                PersonId = person.Id,
                TellNo = person.Info?.TellNo,
                CellNo = person.Info?.CellNo,
                AddressLine1 = person.Info?.AddressLine1,
                AddressLine2 = person.Info?.AddressLine2,
                AddressLine3 = person.Info?.AddressLine3,
                AddressCode = person.Info?.AddressCode,
                PostalAddress1 = person.Info?.PostalAddress1,
                PostalAddress2 = person.Info?.PostalAddress2,
                PostalCode = person.Info?.PostalCode
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateInfo(InfoViewModel model)
        {
            var info = new Info
            {
                PersonId = model.PersonId,
                TellNo = model.TellNo,
                CellNo = model.CellNo,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                AddressLine3 = model.AddressLine3,
                AddressCode = model.AddressCode,
                PostalAddress1 = model.PostalAddress1,
                PostalAddress2 = model.PostalAddress2,
                PostalCode = model.PostalCode
            };

            _userService.UpdateInfo(info);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult UpdatePassword(int personId, string newPassword)
        {
            _userService.UpdatePassword(personId, newPassword);
            return Json(new { success = true });
        }
    }
}
