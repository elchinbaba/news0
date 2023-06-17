using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News0.Web.Data
{
    static public class NewsList
    {
        static public List<Models.NewsViewModel> All = new List<Models.NewsViewModel>()
        {
            new Models.NewsViewModel()
            {
                Id = 1,
                Title = "Hello Everyone",
                Content = "This is our first news",
                Language = "Eng",
                PublishDate = DateTime.Now
            },
            new Models.NewsViewModel()
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
