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
        }

        public Domain.Dtos.NewsDto Select(int id)
        {
            var postTranslation = _context.PostTranslations.Find(id);

            return _mapper.Map<Domain.Dtos.NewsDto>(postTranslation);
        }

        public void Create(Domain.Dtos.NewsDto newsDto)
        {
            var postEntity = _mapper.Map<Domain.Entities.Post>(newsDto);
            var post = _context.Posts.Add(postEntity);
            _context.SaveChanges();

            var postTranslation = _mapper.Map<Domain.Entities.PostTranslation>(newsDto);
            postTranslation.PostId = post.Entity.Id;

            _context.PostTranslations.Add(postTranslation);
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
