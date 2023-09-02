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
                //postDto.PublisherId = (int)HttpContext.Session.GetInt32("Id");
                postDto.PublisherId = 2;
                postDto.PublishDate = DateTime.Now;

                // Call your service or repository method to save the post
                _services.postService.Create(postDto);

                // Redirect to the desired page, e.g., the list of post
                return RedirectToAction("Post", "Admin");
            }

            //model.Categories = GetCategorySelectList();
            //model.Languages = GetLanguageSelectList();

            // If the model state is not valid, return the view with validation errors
            return View("Post/Create", model);
        }

        [Route("Admin/Post/Edit/{id:int}/Translation/Create")]
        public IActionResult PostTranslationCreate(int id)
        {
            var model = new Models.Post.PostTranslationCreationViewModel
            {
                Languages = GetLanguagesWithoutTranslationsForPost(id),
                //Posts = GetPostSelectList(),
                PostId = id
            };

            return View("Post/Translation/Create", model);
        }

        [Route("Admin/Post/Edit/{id:int}/Translation/Create")]
        [HttpPost]
        public IActionResult PostTranslationCreate(Models.Post.PostTranslationCreationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Mapping from PostTranslationCreationViewModel to PostTranslationDto
                var postTranslationDto = _mapper.Map<Domain.Dtos.PostTranslationDto>(model);
                //postTranslationDto.PublisherId = (int)HttpContext.Session.GetInt32("Id");
                postTranslationDto.Id = 0;
                postTranslationDto.PostId = model.Id;
                postTranslationDto.PublisherId = 2;
                postTranslationDto.PublishDate = DateTime.Now;
                // Call your service or repository method to save the category
                _services.postService.CreateTranslation(postTranslationDto);

                // Redirect to the desired page, e.g., the list of category
                return RedirectToAction("Post", "Admin");
            }

            // If the model state is not valid, return the view with validation errors
            return View("Post/Translation/Create", model);
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

        [Route("Admin/Post/Edit/{id:int}")]
        public IActionResult PostEdit(int id)
        {
            var postDto = _services.postService.SelectPostByTranslation(id);

            var model = _mapper.Map<Models.Post.PostEditionViewModel>(postDto);
            var postTranslationDto = _services.postService.SelectTranslation(id);

            model.Title = postTranslationDto.Title;
            model.Content = postTranslationDto.Content;

            model.Categories = GetCategorySelectList();

            return View("Post/Edit", model);
        }

        [Route("Admin/Post/Edit/{id:int}")]
        [HttpPost]
        public IActionResult PostEdit(int id, Models.Post.PostEditionViewModel model)
        {
            //model.Categories = GetCategorySelectList();

            if (ModelState.IsValid)
            {
                var postDto = _services.postService.SelectPostByTranslation(id);

                postDto.CategoryId = model.CategoryId;
                postDto.Category = _mapper.Map<Domain.Entities.Category>(_services.categoryService.Select(model.CategoryId));
                
                var postTranslationDto = _services.postService.SelectTranslation(id);

                model.Language = postTranslationDto.Language;
                model.LanguageId = postTranslationDto.LanguageId;

                model.PostId = postDto.Id;
                model.Id = postTranslationDto.Id;
                model.PublisherId = 2;

                _services.postService.UpdateTranslation(_mapper.Map<Domain.Dtos.PostTranslationDto>(model));
                _services.postService.Update(postDto);

                return RedirectToAction("Post", "Admin");
            }

            return View("Post/Edit", model);
        }

        [Route("Admin/Post/Delete")]
        public IActionResult PostDelete(int id)
        {
            _services.postService.Delete(_services.postService.SelectTranslation(id));
            return RedirectToAction("Post", "Admin");
        }

        public IActionResult Language()
        {
            var languageDtos = _services.languageService.Select();

            return View("Language/Index", _mapper.Map<List<Models.LanguageViewModel>>(languageDtos));
        }

        [Route("Admin/Language/Create")]
        public IActionResult LanguageCreate()
        {
            var model = new Models.LanguageViewModel();

            return View("Language/Create", model);
        }

        [Route("Admin/Language/Create")]
        [HttpPost]
        public IActionResult LanguageCreate(Models.LanguageViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Mapping from LanguageViewModel to LanguageDto
                var languageDto = _mapper.Map<Domain.Dtos.LanguageDto>(model);

                // Call your service or repository method to save the language
                _services.languageService.Create(languageDto);

                // Redirect to the desired page, e.g., the list of language
                return RedirectToAction("Language", "Admin");
            }

            // If the model state is not valid, return the view with validation errors
            return View("Language/Create", model);
        }

        [Route("Admin/Language/Delete")]
        public IActionResult LanguageDelete(int id)
        {
            _services.languageService.Delete(_services.languageService.Select(id));
            return RedirectToAction("Language", "Admin");
        }

        public IActionResult Category()
        {
            var categoryDtos = _services.categoryService.Select();

            return View("Category/Index", _mapper.Map<List<Models.CategoryViewModel>>(categoryDtos));
        }

        [Route("Admin/Category/Create")]
        public IActionResult CategoryCreate()
        {
            //var model = new Models.CategoryViewModel
            //{
            //    Languages = GetLanguageSelectList(),
            //    //LanguagesNames = GetLanguageSelectList().Select(l => l.Text.ToString()).ToList()
            //};

            return View("Category/Create");
        }

        [Route("Admin/Category/Create")]
        [HttpPost]
        public IActionResult CategoryCreate(Models.CategoryViewModel model)
        {
            //model.Languages = GetLanguageSelectList();
            //model.LanguagesNames = model.Languages.Select(l => l.Text.ToString()).ToList();

            if (ModelState.IsValid)
            {
                // Mapping from CategoryCreationViewModel to CategoryDto
                var categoryDto = _mapper.Map<Domain.Dtos.CategoryDto>(model);

                // Call your service or repository method to save the category
                _services.categoryService.Create(categoryDto);

                // Redirect to the desired page, e.g., the list of category
                return RedirectToAction("Category", "Admin");
            }

            // If the model state is not valid, return the view with validation errors
            return View("Category/Create", model);
        }

        [Route("Admin/Category/Translation/Create")]
        public IActionResult CategoryTranslationCreate()
        {
            var model = new Models.CategoryTranslationViewModel
            {
                Categories = GetCategorySelectList(),
                Languages = GetLanguageSelectList()
            };

            return View("Category/Translation/Create", model);
        }

        [Route("Admin/Category/Translation/Create")]
        [HttpPost]
        public IActionResult CategoryTranslationCreate(Models.CategoryTranslationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Mapping from CategoryTranslationViewModel to CategoryTranslationDto
                var categoryTranslationDto = _mapper.Map<Domain.Dtos.CategoryTranslationDto>(model);

                // Call your service or repository method to save the category
                _services.categoryService.CreateTranslation(categoryTranslationDto);

                // Redirect to the desired page, e.g., the list of category
                return RedirectToAction("Category", "Admin");
            }

            // If the model state is not valid, return the view with validation errors
            return View("Category/Translation/Create", model);
        }

        [Route("Admin/Category/Delete")]
        public IActionResult CategoryDelete(int id)
        {
            _services.categoryService.Delete(_services.categoryService.Select(id));
            return RedirectToAction("Category", "Admin");
        }

        private bool IsAuthorized()
        {
            return true;

            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return false;
            }

            return true;
        }

        //private IEnumerable<SelectListItem> GetPostSelectList()
        //{
        //    // Retrieve posts from the database or any other source
        //    // and return them as a SelectList
        //    var posts = _services.postService.SelectPosts();
        //    return new SelectList(posts, "Id", "Id");
        //}

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
            var languages = _services.languageService.Select();
            return new SelectList(languages, "Id", "Name");
        }

        private IEnumerable<SelectListItem> GetLanguagesWithoutTranslationsForPost(int postId)
        {
            // Get the languages that have translations for the specific post
            var languagesWithTranslations = _services.postService.SelectPostTranslations()
                .Where(pt => pt.PostId == postId)
                .Select(pt => pt.LanguageId)
                .ToList();

            // Get all available languages
            var allLanguages = _services.languageService.Select();

            // Filter out the languages that already have translations
            var languagesWithoutTranslations = allLanguages
                .Where(lang => !languagesWithTranslations.Contains(lang.Id))
                .ToList();

            return new SelectList(languagesWithoutTranslations, "Id", "Name");
            //return languagesWithoutTranslations;
        }

    }
}
