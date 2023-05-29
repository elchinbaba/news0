using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News0.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<PostTranslation> PostTranslations { get; set; }
    }
}
