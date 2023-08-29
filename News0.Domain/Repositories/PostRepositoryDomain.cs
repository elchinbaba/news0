using System;
using System.Collections.Generic;
using System.Text;

namespace News0.Domain.Repositories
{
    public interface PostRepositoryDomain
    {
        public List<Dtos.PostDto> Select();
        public Dtos.PostDto Select(int id);
        public void Create(Dtos.PostDto postDto);
        public void Update(Dtos.PostDto postDto);
        public void Delete(Entities.PostTranslation postTranslation);
    }
}
