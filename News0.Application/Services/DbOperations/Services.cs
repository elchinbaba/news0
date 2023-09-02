using System;
using System.Collections.Generic;
using System.Text;

namespace News0.Application.Services.DbOperations
{
    public class Services
    {
        public PostService postService;
        public CategoryService categoryService;
        public LanguageService languageService;
        public UserService userService;

        public Services(PostService postService, CategoryService categoryService, LanguageService languageService, UserService userService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
            this.languageService = languageService;
            this.userService = userService;
        }
    }
}
