using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News0.Domain.Entities
{
    public class PostTranslation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime InsertDate { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
        public int PublisherId { get; set; }
        public User Publisher { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public ICollection<PostTranslationHashtag> PostTranslationHashtags { get; set; }
    }
}
