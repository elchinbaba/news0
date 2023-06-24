using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using News0.Application.Services.DbOperations;

namespace News0.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsService _newsService;
        private readonly IMapper _mapper;

        public NewsController(NewsService newsService, IMapper mapper)
        {
            _newsService = newsService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var newsDtos = _newsService.Select();

            return View("Index", _mapper.Map<List<Models.NewsViewModel>>(newsDtos));

            //return View("Index", .Select(pt => new Models.NewsViewModel
            //{
            //    Id = pt.Id,
            //    Title = pt.Title,
            //    Content = pt.Content,
            //    PublishDate = pt.PublishDate
            //}).ToList());
        }

        //[Route("News/{id:int}")]
        //public IActionResult Details(int id)
        //{
        //    //var newsDTO = new NewsService(new Infrastructure.NewsContext()).Select(id);
        //    //if (newsDTO == null)
        //    //{
        //    //    return RedirectToAction("NotFound", "Home");
        //    //}

        //    //return View(new Models.NewsViewModel
        //    //{
        //    //    Id = newsDTO.Id,
        //    //    Title = newsDTO.Title,
        //    //    Content = newsDTO.Content,
        //    //    PublishDate = newsDTO.PublishDate
        //    //});
        //}
    }
}
