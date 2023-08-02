using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using src.Services.AuthenticationService.Domain.Entities;

namespace Infrastructure.MappingExtensions
{
    public static class UserExtensions
    {
        public static User ToUser(this RegisterUser userDto)
        {
            return new User
            {

                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                Password = userDto.Password
            };
        }
    }
}