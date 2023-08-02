using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Interfaces;
using Authentication.API.Exceptions;
using Domain.Repositories;
using FluentValidation;
using MediatR;
using src.Services.AuthenticationService.Domain.Entities;



namespace Application.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {

        private readonly IAuthenticateService _authenticateService;
        private readonly IValidator<RegisterUserCommand> _validator;
        public RegisterUserCommandHandler(IAuthenticateService authenticateService, IValidator<RegisterUserCommand> validator)
        {
            _authenticateService = authenticateService;
            _validator = validator;

        }
        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.Select(x => x.ErrorMessage);
                throw new CustomValidationException(errorMessage);

            }

            //check if user with email exists
            var userExists = await _authenticateService.IsAlreadyRegisteredAsync(request.Email);

            if (userExists)
            {
                throw new CustomValidationException(new List<string> { "user with that email already exists" });
            }


            var hashedPass = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Password = hashedPass
            };



            await _authenticateService.RegisterUserAsync(user);

            return user;
        }
    }
}