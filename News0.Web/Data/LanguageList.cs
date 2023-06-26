using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News0.Web.Data
{
    static public class LanguageList
    {
        static public List<Domain.Entities.Language> All = new List<Domain.Entities.Language>()
        {
            new Domain.Entities.Language()
            {
                Id = 2,
                Name = "Azerbaijani"
            },
            new Domain.Entities.Language()
            {
                Id = 1,
                Name = "English"
            },
            new Domain.Entities.Language()
            {
                Id = 3,
                Name = "Russian"
            }
        };
    }
}
