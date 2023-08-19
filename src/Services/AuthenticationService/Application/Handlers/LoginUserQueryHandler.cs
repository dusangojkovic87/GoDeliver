using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries;
using Domain.Models;
using Domain.Repositories;
using MediatR;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.ComponentModel.DataAnnotations;
using Authentication.API.Exceptions;
using Shared.Contracts;
using Application.Interfaces;

namespace Application.Handlers
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, JwtToken>
    {


        private readonly IAuthenticateService _authenticateService;
        private readonly IJwtConfig _jwtConfig;


        public LoginUserQueryHandler(IAuthenticateService authenticateService, IJwtConfig jwtConfig)
        {
            _authenticateService = authenticateService;
            _jwtConfig = jwtConfig;


        }


        public async Task<JwtToken> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var query = new LoginUserDto
            {
                Email = request.Email,
                Password = request.Password

            };



            var user = await _authenticateService.GetUserByEmailAsync(query) ?? throw new CustomValidationException(new List<string> { "Invalid email or password" });
            var arePassEqual = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!arePassEqual)
            {
                throw new CustomValidationException(new List<string> { "Password is incorect!" });

            }


            var secretKey = _jwtConfig.SecretKey;
            var issuer = _jwtConfig.Issuer;
            var audience = _jwtConfig.Audience;

            var userId = user.Id;
            var userEmail = user.Email;
            var expiryInMinutes = 60;

            var token = GenerateJwtToken(secretKey, issuer, audience, userId, userEmail, expiryInMinutes);

            return new JwtToken
            {
                Token = token
            };
        }
        public static string GenerateJwtToken(string secretKey, string issuer, string audience, int userId, string userEmail, int expiryInMinutes)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]{
                    new Claim(JwtRegisteredClaimNames.Sub,userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,userEmail)
            };

            var tokenOptions = new JwtSecurityToken(
                    issuer: issuer,
                    claims: claims,
                    audience: audience,
                    expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                    signingCredentials: credentials
           );



            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;

        }
    }


}