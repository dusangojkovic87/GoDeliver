using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Domain.Repositories;
using src.Services.AuthenticationService.Domain.Entities;

namespace Application.Services
{
    public class AuthenticateService : IAuthenticateService
    {

        private readonly IAuthenticateRepository _authenticateRepository;
        public AuthenticateService(IAuthenticateRepository authenticateRepository)
        {
            _authenticateRepository = authenticateRepository;

        }


        public async Task<User> GetUserByEmailAsync(LoginUserDto user)
        {
            var userFromDb = await _authenticateRepository.GetUserByEmail(user);
            return userFromDb;
        }

        public Task<bool> IsAlreadyRegisteredAsync(string Email)
        {
            var isRegistered = _authenticateRepository.IsAlreadyRegistered(Email);
            return isRegistered;
        }

        public async Task RegisterUserAsync(User user)
        {
            await _authenticateRepository.RegisterUser(user);

        }
    }
}