using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;
using src.Services.AuthenticationService.Domain.Entities;

namespace Application.Queries
{
    public class LoginUserQuery : IRequest<JwtToken>
    {
        public string Email;
        public string Password;
    }
}