using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News0.Infrastructure;
using News0.Application.Services.DbOperations;

namespace News0.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.CategoryViewModel category)
        {
            //_services.categoryService.Create(new Domain.Entities.Category()
            //{
            //    Name = category.Name
            //});
            ////NewsContext newsContext = new NewsContext();
            ////CategoryService categoryService = new CategoryService(newsContext);
            ////categoryService.Create(new Domain.Entities.Category()
            ////{
            ////    Title = category.Title
            ////});
            return View();
        }
    }
}
