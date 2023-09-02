using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using News0.Application.Services.DbOperations;

namespace News0.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var realUser = _userService.Select().Where(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password)).FirstOrDefault();
            if (realUser == null)
            {
                return RedirectToAction("Index");
            }

            HttpContext.Session.SetInt32("Id", realUser.Id);

            return RedirectToAction("Dashboard");
        }

        public ActionResult DashBoard()
        {
            var sessionId = HttpContext.Session.GetInt32("Id");
            if (sessionId == null)
            {
                return RedirectToAction("Index");
            }

            return View(Data.UserList.All.Find(u => u.Id == sessionId));
        }
    }
}
