using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using News0.Application.Services.DbOperations;

namespace News0.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService _postService;
        private readonly IMapper _mapper;

        public PostController(PostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [Route("News")]
        public IActionResult Index()
        {
            var postDtos = _postService.Select().OrderByDescending(p => p.PublishDate).ToList();

            return View("Index", _mapper.Map<List<Models.Post.PostViewModel>>(postDtos));
        }

        [Route("News/{id:int}")]
        public IActionResult Details(int id)
        {
            var postDto = _postService.Select(id);
            if (postDto == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            return View(_mapper.Map<Models.Post.PostViewModel>(postDto));
        }
    }
}
