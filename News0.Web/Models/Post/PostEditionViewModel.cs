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
        public int CategoryId { get; set; }
        public Domain.Entities.Category Category { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
