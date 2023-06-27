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
        private readonly Services _services;
        private readonly IMapper _mapper;

        public PostController(Services services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [Route("News")]
        public IActionResult Index()
        {
            var postDtos = _services.postService.Select();

            return View("Index", _mapper.Map<List<Models.Post.PostViewModel>>(postDtos));
        }

        [Route("News/{id:int}")]
        public IActionResult Details(int id)
        {
            var postDto = _services.postService.Select(id);
            if (postDto == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            return View(_mapper.Map<Models.Post.PostViewModel>(postDto));
        }
    }
}
