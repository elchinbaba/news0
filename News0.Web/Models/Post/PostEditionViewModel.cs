using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace News0.Web.Models.Post
{
    public class PostEditionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int PublisherId { get; set; }
        public int LanguageId { get; set; }
        public Domain.Entities.Language Language { get; set; }
        public int CategoryId { get; set; }
        public Domain.Entities.Category Category { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
