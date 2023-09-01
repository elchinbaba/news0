using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

            _context.Entry(category).State = EntityState.Detached;

            return _mapper.Map<Domain.Dtos.CategoryDto>(category);
        }

        public void Create(Domain.Dtos.CategoryDto categoryDto)
        {
            //var categoryEntity = _mapper.Map<Domain.Entities.Category>(categoryDto);
            //var category = _context.Categories.Add(categoryEntity);
            //_context.SaveChanges();

            //var categoryTranslation = _mapper.Map<Domain.Entities.CategoryTranslation>(categoryDto);

            //_context.CategoryTranslations.Add(categoryTranslation);
            //_context.SaveChanges();

            var category = _mapper.Map<Domain.Entities.Category>(categoryDto);

            _context.Categories.Add(category);

            _context.SaveChanges();
        }

        public void CreateTranslation(Domain.Dtos.CategoryTranslationDto categoryTranslationDto)
        {
            var categoryTranslation = _mapper.Map<Domain.Entities.CategoryTranslation>(categoryTranslationDto);

            _context.CategoryTranslations.Add(categoryTranslation);

            _context.SaveChanges();
        }

        public void Update(Domain.Entities.Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(Domain.Dtos.CategoryDto categoryDto)
        {
            var category = _mapper.Map<Domain.Entities.Category>(categoryDto);
            category.Id = categoryDto.Id;

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
