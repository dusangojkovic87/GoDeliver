using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Queries;
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


        [HttpGet("all")]
        public async Task<IActionResult> GetAllCategories()
        {
            var request = new GetAllCategoriesQuery { };

            var categories = await _mediatr.Send(request);


            return Ok(categories);

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

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteCategory(int Id)
        {

            var request = new DeleteCategoryCommand
            {
                Id = Id

            };

            var result = await _mediatr.Send(request);

            if (result)
            {
                return NoContent();
            }

            return BadRequest("Error happened,category not deleted! ");

        }


        [HttpPost("update/{Id}")]
        public async Task<IActionResult> UpdateCategory(int Id, [FromBody] CategoryDto category)
        {

            var updateCategoryCommand = new UpdateCategoryCommand
            {
                Id = Id,
                Name = category.Name

            };

            var isUpdated = await _mediatr.Send(updateCategoryCommand);

            if (isUpdated)
            {
                return Ok(category);
            }

            return BadRequest("Error,category not updated!");


        }
    }
}