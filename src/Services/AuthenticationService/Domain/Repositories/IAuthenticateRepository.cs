using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using src.Services.AuthenticationService.Domain.Entities;

namespace Domain.Repositories
{
    public interface IAuthenticateRepository
    {
        Task RegisterUser(User user);
        Task<User> GetUserByEmail(LoginUserDto user);
        Task<bool> IsAlreadyRegistered(string Email);

    }
}