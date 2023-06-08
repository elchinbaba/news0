using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News0.Web.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Language { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
