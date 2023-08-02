using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Application.Commands;
using Application.Queries;
using Authentication.API.Dtos;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Auth : ControllerBase
    {
        private readonly IMediator _mediator;

        public Auth(IMediator mediator)
        {
            _mediator = mediator;

        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationRequest request)
        {
            var registerUserCommand = new RegisterUserCommand
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Password = request.Password

            };

            var result = await _mediator.Send(registerUserCommand);

            return Ok(result);

        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginRequest request)
        {

            var loginUserCommand = new LoginUserQuery
            {
                Email = request.Email,
                Password = request.Password
            };


            var tokenData = await _mediator.Send(loginUserCommand);
            return Ok(new { tokenData.Token });



        }
    }
}