using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News0.Web.Data
{
    static public class CategoryList
    {
        static public List<Domain.Entities.Category> All = new List<Domain.Entities.Category>()
        {
            new Domain.Entities.Category()
            {
                Id = 1,
                Name = "hello"
            },
            new Domain.Entities.Category()
            {
                Id = 2,
                Name = "Private"
            }
        };
    }
}
