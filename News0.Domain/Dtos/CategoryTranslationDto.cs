using System;
using System.Collections.Generic;
using System.Text;

namespace News0.Domain.Dtos
{
    public class CategoryTranslationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
    }
}
