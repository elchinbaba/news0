using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News0.Web.Data
{
    static public class UsersList
    {
        static public List<Models.UserViewModel> All = new List<Models.UserViewModel>()
        {
            new Models.UserViewModel()
            {
                Id = 1,
                Email = "hello@gmail.com",
                Password = "hello"
            },
            new Models.UserViewModel()
            {
                Id = 2,
                Email = "hi@gmail.com",
                Password = "hi"
            }
        };
    }
}
