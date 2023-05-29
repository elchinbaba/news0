using System;
using System.Collections.Generic;
using System.Text;
using News0.Domain.Entities;
using News0.Domain.Repositories;

namespace News0.Application.Services.DbOperations
{
    public class CategoryService : CategoryRepositoryDomain
    {
        private readonly NewsContextDomain _context;
        public CategoryService(NewsContextDomain context)
        {
            _context = context;
        }
        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
