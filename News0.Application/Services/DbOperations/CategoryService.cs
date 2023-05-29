using System;
using System.Collections.Generic;
using System.Text;
using News0.Domain.Repositories;

namespace News0.Application.Services.DbOperations
{
    public class CategoryService : CategoryRepositoryDomain
    {
        private readonly NewsContextApplication _context;
        public CategoryService(NewsContextApplication context)
        {
            _context = context;
        }
        public void Create(Domain.Entities.Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Domain.Entities.Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(Domain.Entities.Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
