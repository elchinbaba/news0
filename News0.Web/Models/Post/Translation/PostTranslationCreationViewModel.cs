using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace News0.Web.Models.Post
{
    public class PostTranslationCreationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int LanguageId { get; set; }
        public IEnumerable<SelectListItem> Languages { get; set; }
        public int PostId { get; set; }
        //public IEnumerable<SelectListItem> Posts { get; set; }
    }
}