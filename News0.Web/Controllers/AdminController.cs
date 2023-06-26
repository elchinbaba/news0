using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using News0.Application.Services.DbOperations;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var model = new Models.NewsCreationViewModel
            {
                Categories = GetCategorySelectList(),
                Languages = GetLanguageSelectList()
            };

            return View("News/Create", model);
        }

        [Route("Admin/News/Create")]
        [HttpPost]
        public IActionResult NewsCreate(Models.NewsCreationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Mapping from NewsCreationViewModel to NewsDto
                var newsDto = _mapper.Map<Domain.Dtos.NewsDto>(model);
                newsDto.PublisherId = (int)HttpContext.Session.GetInt32("Id");

                // Call your service or repository method to save the news
                _newsService.Create(newsDto);

                // Redirect to the desired page, e.g., the list of news
                return RedirectToAction("Index", "News");
            }

            model.Categories = GetCategorySelectList();
            model.Languages = GetLanguageSelectList();

            // If the model state is not valid, return the view with validation errors
            return View("News/Create", model);
        }


        [Route("Admin/News/{id:int}")]
        public IActionResult NewsDetails(int id)
        {
            var newsDto = _newsService.Select(id);
            if (newsDto == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            return View("News/Details", _mapper.Map<Models.NewsViewModel>(newsDto));
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

        private bool IsAuthorized()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return false;
            }

            return true;
        }

        private IEnumerable<SelectListItem> GetCategorySelectList()
        {
            // Retrieve categories from the database or any other source
            // and return them as a SelectList
            var categories = Data.CategoryList.All;
            return new SelectList(categories, "Id", "Name");
        }

        private IEnumerable<SelectListItem> GetLanguageSelectList()
        {
            // Retrieve languages from the database or any other source
            // and return them as a SelectList
            var languages = Data.LanguageList.All;
            return new SelectList(languages, "Id", "Name");
        }
    }
}
