using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News0.Domain.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PostTranslation> PostTranslations { get; set; }
        public ICollection<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
