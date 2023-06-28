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
        private readonly Services _services;
        private readonly IMapper _mapper;

        public AdminController(Services services, IMapper mapper)
        {
            _services = services;
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
        public IActionResult Post()
        {
            var postDtos = _services.postService.Select();

            return View("Post/Index", _mapper.Map<List<Models.Post.PostViewModel>>(postDtos));
        }

        [Route("Admin/Post/Create")]
        public IActionResult PostCreate()
        {
            var model = new Models.Post.PostCreationViewModel
            {
                Categories = GetCategorySelectList(),
                Languages = GetLanguageSelectList()
            };

            return View("Post/Create", model);
        }

        [Route("Admin/Post/Create")]
        [HttpPost]
        public IActionResult PostCreate(Models.Post.PostCreationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Mapping from PostCreationViewModel to PostDto
                var postDto = _mapper.Map<Domain.Dtos.PostDto>(model);
                postDto.PublisherId = (int)HttpContext.Session.GetInt32("Id");

                // Call your service or repository method to save the post
                _services.postService.Create(postDto);

                // Redirect to the desired page, e.g., the list of post
                return RedirectToAction("Post", "Admin");
            }

            model.Categories = GetCategorySelectList();
            model.Languages = GetLanguageSelectList();

            // If the model state is not valid, return the view with validation errors
            return View("Post/Create", model);
        }

        [Route("Admin/Post/{id:int}")]
        public IActionResult PostDetails(int id)
        {
            var postDto = _services.postService.Select(id);
            if (postDto == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            return View("Post/Details", _mapper.Map<Models.Post.PostViewModel>(postDto));
        }

        [Route("Admin/Post/Edit")]
        public IActionResult PostEdit()
        {
            return View("Post/Edit");
        }

        [Route("Admin/Post/Delete")]
        public IActionResult PostDelete()
        {
            return View("Post/Delete");
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
            var categories = _services.categoryService.Select();
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
