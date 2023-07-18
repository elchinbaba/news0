using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace News0.Application.Services.DbOperations
{
    public class CategoryService : Domain.Repositories.CategoryRepositoryDomain
    {
        private readonly NewsContextApplication _context;
        private readonly IMapper _mapper;

        public CategoryService(NewsContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Domain.Dtos.CategoryDto> Select()
        {
            var categories = _context.Categories.ToList();

            return _mapper.Map<List<Domain.Dtos.CategoryDto>>(categories);
        }

        public Domain.Dtos.CategoryDto Select(int id)
        {
            var category = _context.Categories.Find(id);

            return _mapper.Map<Domain.Dtos.CategoryDto>(category);
        }
        public void Create(Domain.Dtos.CategoryDto categoryDto)
        {
            var category = _mapper.Map<Domain.Entities.Category>(categoryDto);

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
