
using System.Security.Cryptography.X509Certificates;
using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class UserValidator : AbstractValidator<RegisterUserCommand>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid!");
            RuleFor(x => x.Password).MinimumLength(4).WithMessage("Password length is too short");


        }

    }
}