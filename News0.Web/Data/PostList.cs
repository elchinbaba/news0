using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News0.Web.Data
{
    static public class PostList
    {
        static public List<Models.Post.PostViewModel> All = new List<Models.Post.PostViewModel>()
        {
            new Models.Post.PostViewModel()
            {
                Id = 1,
                Title = "Hello Everyone",
                Content = "This is our first news",
                Language = "Eng",
                PublishDate = DateTime.Now
            },
            new Models.Post.PostViewModel()
            {
                Id = 2,
                Title = "Hi everyone",
                Content = "This is our second news",
                Language = "Eng",
                PublishDate = DateTime.Now
            }
        };
    }

}
