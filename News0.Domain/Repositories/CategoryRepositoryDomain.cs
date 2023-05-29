using System;
using System.Collections.Generic;
using System.Text;
using News0.Domain.Entities;

namespace News0.Domain.Repositories
{
    public interface CategoryRepositoryDomain
    {
        public void Create(Category category);
        public void Update(Category category);
        public void Delete(Category category);
    }
}
