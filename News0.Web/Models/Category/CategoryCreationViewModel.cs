using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace News0.Web.Models
{
    public class CategoryCreationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SelectListItem> Languages { get; set; }
    }
}
