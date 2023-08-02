using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using src.Services.AuthenticationService.Domain.Entities;

namespace Application.Interfaces
{
    public interface IAuthenticateService
    {
        Task RegisterUserAsync(User user);
        Task<User> GetUserByEmailAsync(LoginUserDto user);
        Task<bool> IsAlreadyRegisteredAsync(string Email);

    }
}