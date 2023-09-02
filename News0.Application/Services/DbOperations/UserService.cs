using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace News0.Application.Services.DbOperations
{
    public class UserService : Domain.Repositories.UserRepositoryDomain
    {
        private readonly NewsContextApplication _context;
        private readonly IMapper _mapper;

        public UserService(NewsContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Domain.Dtos.UserDto> Select()
        {
            var users = _context.Users.ToList();

            return _mapper.Map<List<Domain.Dtos.UserDto>>(users);
        }

        public Domain.Dtos.UserDto Select(int id)
        {
            var user = _context.Users.Find(id);

            _context.Entry(user).State = EntityState.Detached;

            return _mapper.Map<Domain.Dtos.UserDto>(user);
        }

        public void Create(Domain.Dtos.UserDto userDto)
        {
            var user = _mapper.Map<Domain.Entities.User>(userDto);

            _context.Users.Add(user);

            _context.SaveChanges();
        }

        public void Update(Domain.Entities.User user)
        {

        }

        public void Delete(Domain.Dtos.UserDto userDto)
        {
            var user = _mapper.Map<Domain.Entities.User>(userDto);
            user.Id = userDto.Id;

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
