using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using News0.Application.Services.DbOperations;

namespace News0.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly NewsService _newsService;
        private readonly IMapper _mapper;

        public AdminController(NewsService newsService, IMapper mapper)
        {
            _newsService = newsService;
            _mapper = mapper;
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
            var newsDtos = _newsService.Select();

            return View("News/Index", _mapper.Map<List<Models.NewsViewModel>>(newsDtos));
        }

        [Route("Admin/News/Create")]
        public IActionResult NewsCreate()
        {
            return View("News/Create");
        }

        //[Route("Admin/News/{id:int}")]
        //public IActionResult NewsDetails(int id)
        //{
        //    var pt = new Application.Services.DbOperations.NewsService(new Infrastructure.NewsContext()).Select(id);
        //    if (pt == null)
        //    {
        //        return RedirectToAction("NotFound", "Home");
        //    }

        //    return View("News/Details", new Models.NewsViewModel
        //    {
        //        Id = pt.Id,
        //        Title = pt.Title,
        //        Content = pt.Content,
        //        PublishDate = pt.PublishDate
        //    });
        //}

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

        private bool IsAuthorized()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return false;
            }

            return true;
        }
    }
}
