using System;
using System.Collections.Generic;
using System.Text;

namespace News0.Domain.Repositories
{
    public interface LanguageRepositoryDomain
    {
        public List<Dtos.LanguageDto> Select();
        public Dtos.LanguageDto Select(int id);
        public void Create(Dtos.LanguageDto languageDto);
        public void Update(Entities.Language language);
        public void Delete(Dtos.LanguageDto languageDto);
    }
}
