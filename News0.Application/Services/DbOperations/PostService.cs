using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace News0.Application.Services.DbOperations
{
    public class PostService : Domain.Repositories.PostRepositoryDomain
    {
        private readonly NewsContextApplication _context;
        private readonly IMapper _mapper;

        public PostService(NewsContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Domain.Dtos.PostDto> Select()
        {
            var postTranslations = _context.PostTranslations.ToList();

            return _mapper.Map<List<Domain.Dtos.PostDto>>(postTranslations);
        }

        public Domain.Dtos.PostDto Select(int id)
        {
            var postTranslation = _context.PostTranslations.Find(id);

            return _mapper.Map<Domain.Dtos.PostDto>(postTranslation);
        }

        public void Create(Domain.Dtos.PostDto postDto)
        {
            var postEntity = _mapper.Map<Domain.Entities.Post>(postDto);
            var post = _context.Posts.Add(postEntity);
            _context.SaveChanges();

            var postTranslation = _mapper.Map<Domain.Entities.PostTranslation>(postDto);
            postTranslation.PostId = post.Entity.Id;

            _context.PostTranslations.Add(postTranslation);
            _context.SaveChanges();
        }

        public void Update(Domain.Entities.PostTranslation postTranslation)
        {
            _context.PostTranslations.Update(postTranslation);
            _context.SaveChanges();
        }

        public void Delete(Domain.Entities.PostTranslation postTranslation)
        {
            _context.PostTranslations.Remove(postTranslation);
            _context.SaveChanges();
        }
    }
}
