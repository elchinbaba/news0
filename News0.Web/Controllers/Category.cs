using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News0.Infrastructure;
using News0.Application.Services.DbOperations;

namespace News0.Web.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.CategoryViewModel category)
        {
            NewsContext newsContext = new NewsContext();
            CategoryService categoryService = new CategoryService(newsContext);
            categoryService.Create(new Domain.Entities.Category()
            {
                Name = category.Name
            });
            return View();
        }
    }
}
