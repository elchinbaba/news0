using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace News0.Application.Services.DbOperations
{
    public class LanguageService : Domain.Repositories.LanguageRepositoryDomain
    {
        private readonly NewsContextApplication _context;
        private readonly IMapper _mapper;

        public LanguageService(NewsContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Domain.Dtos.LanguageDto> Select()
        {
            var languages = _context.Languages.ToList();

            return _mapper.Map<List<Domain.Dtos.LanguageDto>>(languages);
        }
        public Domain.Dtos.LanguageDto Select(int id)
        {
            var language = _context.Languages.Find(id);

            return _mapper.Map<Domain.Dtos.LanguageDto>(language);
        }

        public void Create(Domain.Dtos.LanguageDto languageDto)
        {
            var language = _mapper.Map<Domain.Entities.Language>(languageDto);

            _context.Languages.Add(language);

            _context.SaveChanges();
        }
        public void Update(Domain.Entities.Language language)
        {

        }
        public void Delete(Domain.Entities.Language language)
        {

        }
    }
}
