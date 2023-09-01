using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public List<Domain.Dtos.PostTranslationDto> SelectPostTranslations()
        {
            var postTranslations = _context.PostTranslations.ToList();

            return _mapper.Map<List<Domain.Dtos.PostTranslationDto>>(postTranslations);
        }

        public Domain.Dtos.PostDto SelectPostByTranslation(int id)
        {
            var post = _context.Posts.FirstOrDefault(
                p => p.Id == _context.PostTranslations.Where(
                    pt => pt.Id == id)
                .Select(pt => pt.PostId)
                .FirstOrDefault()
                );

            post.Category = _context.Categories.Find(post.CategoryId);
            var postDto = _mapper.Map<Domain.Dtos.PostDto>(post);

            _context.Entry(post).State = EntityState.Detached;

            return postDto;
        }

        public List<Domain.Dtos.PostDto> SelectPosts()
        {
            var posts = _context.Posts.ToList();

            return _mapper.Map<List<Domain.Dtos.PostDto>>(posts);
        }

        public Domain.Dtos.PostDto Select(int id)
        {
            var postTranslation = _context.PostTranslations.Find(id);

            return _mapper.Map<Domain.Dtos.PostDto>(postTranslation);
        }

        public Domain.Dtos.PostTranslationDto SelectTranslation(int id)
        {
            var postTranslation = _context.PostTranslations.Find(id);

            _context.Entry(postTranslation).State = EntityState.Detached;

            return _mapper.Map<Domain.Dtos.PostTranslationDto>(postTranslation);
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

        public void CreateTranslation(Domain.Dtos.PostTranslationDto postTranslationDto)
        {
            var postTranslation = _mapper.Map<Domain.Entities.PostTranslation>(postTranslationDto);

            _context.PostTranslations.Add(postTranslation);

            _context.SaveChanges();
        }

        public void Update(Domain.Dtos.PostDto postDto)
        {
            var post = _mapper.Map<Domain.Entities.Post>(postDto);

            //_context.Entry(post).State = EntityState.Detached;

            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void UpdateTranslation(Domain.Dtos.PostTranslationDto postTranslationDto)
        {
            var postTranslation = _mapper.Map<Domain.Entities.PostTranslation>(postTranslationDto);
            postTranslation.Id = postTranslationDto.Id;
            //_context.Entry(post).State = EntityState.Detached;

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
