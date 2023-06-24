using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace News0.Application.Services.DbOperations
{
    public class NewsService : Domain.Repositories.NewsRepositoryDomain
    {
        private readonly NewsContextApplication _context;
        private readonly IMapper _mapper;

        public NewsService(NewsContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Domain.Dtos.NewsDto> Select()
        {
            var postTranslations = _context.PostTranslations.ToList();

            return _mapper.Map<List<Domain.Dtos.NewsDto>>(postTranslations);

            //return _context.PostTranslations.ToList().Select(pt => new Domain.Dtos.NewsDto
            //{
            //    Id = pt.Id,
            //    Title = pt.Title,
            //    Content = pt.Content,
            //    Language = pt.Language.Name,
            //    PublishDate = pt.PublishDate
            //}).ToList();
        }

        public Domain.Dtos.NewsDto Select(int id)
        {
            Domain.Entities.PostTranslation postTranslation = _context.PostTranslations.Find(id);
            return new Domain.Dtos.NewsDto
            {
                Id = postTranslation.Id,
                Title = postTranslation.Title,
                Content = postTranslation.Content,
                Language = postTranslation.Language.Name,
                PublishDate = postTranslation.PublishDate
            };
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
