using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Dtos;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Category : ControllerBase
    {

        private readonly IMediator _mediatr;
        public Category(IMediator mediator)
        {
            _mediatr = mediator;
        }



        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto category)
        {

            var request = new AddCategoryCommand
            {
                Name = category.Name

            };


            var result = await _mediatr.Send(request);

            return Ok(result);
        }
    }
}