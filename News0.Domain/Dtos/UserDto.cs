using System;
using System.Collections.Generic;
using System.Text;

namespace News0.Domain.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }
        public Entities.Role Role { get; set; }
    }
}
