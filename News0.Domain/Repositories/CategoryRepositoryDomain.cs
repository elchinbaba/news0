using System;
using System.Collections.Generic;
using System.Text;

namespace News0.Domain.Repositories
{
    public interface CategoryRepositoryDomain
    {
        public void Create(Entities.Category category);
        public void Update(Entities.Category category);
        public void Delete(Entities.Category category);
    }
}
