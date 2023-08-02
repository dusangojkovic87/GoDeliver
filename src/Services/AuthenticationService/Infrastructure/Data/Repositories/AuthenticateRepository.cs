using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.MappingExtensions;
using Microsoft.EntityFrameworkCore;
using src.Services.AuthenticationService.Domain.Entities;

namespace Infrastructure.Data.Repositories
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly AuthenticationDbContext _context;
        public AuthenticateRepository(AuthenticationDbContext context)
        {
            _context = context;

        }
        public async Task RegisterUser(User user)
        {

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

        }

        public async Task<User> GetUserByEmail(LoginUserDto user)
        {
            var userFromDb = await _context.Users.SingleOrDefaultAsync(x => x.Email == user.Email);
            return userFromDb;

        }

        public async Task<bool> IsAlreadyRegistered(string Email)
        {
            var userExists = await _context.Users.FirstAsync(users => users.Email == Email);
            if (userExists == null)
            {
                return false;

            }



            return true;

        }
    }
}