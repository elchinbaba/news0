using System;
using System.Collections.Generic;
using System.Text;

namespace News0.Domain.Dtos
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Language { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
