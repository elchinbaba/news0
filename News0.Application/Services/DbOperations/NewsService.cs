using System;
using System.Collections.Generic;
using System.Text;

namespace News0.Application.Services.DbOperations
{
    public class NewsService
    {
        private readonly NewsContextApplication _context;
        public NewsService(NewsContextApplication context)
        {
            _context = context;
        }

        public void Create(Domain.Entities.PostTranslation news)
        {
            _context.PostTranslations.Add(news);
            _context.SaveChanges();
        }

        public void Update(Domain.Entities.PostTranslation news)
        {
            _context.PostTranslations.Update(news);
            _context.SaveChanges();
        }

        public void Delete(Domain.Entities.PostTranslation news)
        {
            _context.PostTranslations.Remove(news);
            _context.SaveChanges();
        }
    }
}
