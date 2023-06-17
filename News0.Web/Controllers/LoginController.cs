using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace News0.Web.Controllers
{
    public class LoginController : Controller
    {
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

            Models.UserViewModel realUser = Data.UsersList.All.Where(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password)).FirstOrDefault();
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

            return View(Data.UsersList.All.Find(u => u.Id == sessionId));
        }
    }
}
