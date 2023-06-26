using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News0.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CategoryTranslation> CategoryTranslations { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
