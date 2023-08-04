using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Handlers;
using Application.Queries;
using Domain.Models;
using MediatR;
using src.Services.AuthenticationService.Domain.Entities;

namespace Authentication.API.Extensions
{
    public static class AddCqrsHandlersExtension
    {
        public static IServiceCollection AddCqrsHandlers(this IServiceCollection service)
        {

            service.AddScoped<IRequestHandler<RegisterUserCommand, User>, RegisterUserCommandHandler>();
            service.AddScoped<IRequestHandler<LoginUserQuery, JwtToken>, LoginUserQueryHandler>();

            return service;

        }

    }
}