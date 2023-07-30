using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace News0.Web.Models
{
    public class CategoryTranslationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public DateTime PublishDate { get; set; }

        public int LanguageId { get; set; }
        public IEnumerable<SelectListItem> Languages { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
