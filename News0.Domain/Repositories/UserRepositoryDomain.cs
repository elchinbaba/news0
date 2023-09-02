using System;
using System.Collections.Generic;
using System.Text;

namespace News0.Domain.Repositories
{
    public interface UserRepositoryDomain
    {
        public List<Dtos.UserDto> Select();
        public Dtos.UserDto Select(int id);
        public void Create(Dtos.UserDto userDto);
        public void Update(Entities.User user);
        public void Delete(Dtos.UserDto userDto);
    }
}
