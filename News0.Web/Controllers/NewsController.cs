using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News0.Web.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View(Data.NewsList.All);
        }
        public IActionResult Details(int id)
        {
            return View(Data.NewsList.All.FirstOrDefault(news => news.Id == id));
        }
    }
}
