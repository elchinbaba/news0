using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace News0.Web.Controllers
{
    public class AdminController : Controller
    {
        private bool IsAuthorized()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return false;
            }

            return true;
        }

        public IActionResult Index()
        {
            if (!IsAuthorized())
            {
                return RedirectToAction("NotFound", "Home");
            }

            return View();
        }
        public IActionResult News()
        {
            return View("News/Index", Data.NewsList.All);
        }

        [Route("Admin/News/Create")]
        public IActionResult NewsCreate()
        {
            return View("News/Create");
        }

        [Route("News/Details")]
        public IActionResult NewsDetails()
        {
            return View("News/Details");
        }

        [Route("Admin/News/Edit")]
        public IActionResult NewsEdit()
        {
            return View("News/Edit");
        }

        [Route("Admin/News/Delete")]
        public IActionResult NewsDelete()
        {
            return View("News/Delete");
        }
    }
}
