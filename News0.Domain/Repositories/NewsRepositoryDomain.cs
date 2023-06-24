using System;
using System.Collections.Generic;
using System.Text;

namespace News0.Domain.Repositories
{
    public interface NewsRepositoryDomain
    {
        public List<Dtos.NewsDto> Select();
        public Dtos.NewsDto Select(int id);
        public void Create(Entities.PostTranslation postTranslation);
        public void Update(Entities.PostTranslation postTranslation);
        public void Delete(Entities.PostTranslation postTranslation);
    }
}
