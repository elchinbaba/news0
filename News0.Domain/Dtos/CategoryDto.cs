using System;
using System.Collections.Generic;
using System.Text;

namespace News0.Domain.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }

        //public ICollection<CategoryTranslationDto> CategoryTranslationDtos { get; set; }
    }
}
