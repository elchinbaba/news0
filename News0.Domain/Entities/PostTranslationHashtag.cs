using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News0.Domain.Entities
{
    public class PostTranslationHashtag
    {
        public int Id { get; set; }

        public int HashtagId { get; set; }
        public Hashtag Hashtag { get; set; }
        public int PostTranslationId { get; set; }
        public PostTranslation PostTranslation { get; set; }
    }
}
