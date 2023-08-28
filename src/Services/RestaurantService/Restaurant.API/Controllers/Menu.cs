using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Menu;
using Domain.Models.Menu;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Util.UploadImage;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Menu : ControllerBase
    {
        private readonly IMediator _mediator;
        public IWebHostEnvironment _webHostEnvironment { get; }

        public Menu(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _mediator = mediator;
        }



        [HttpPost("add/{Id}")]
        public async Task<IActionResult> AddMenuToRestaurant(int Id, [FromForm] AddMenuRequestDto requestDto, [FromForm] IFormFile imageFile)
        {
            var root = _webHostEnvironment.ContentRootPath;
            var imagePath = Path.Combine(root, "wwwroot", "images");
            var imageName = "default.png";
            if (imageFile != null)
            {
                imageName = UploadImageHelper.UploadImage(imageFile, imagePath, imageFile.Name, imageFile.ContentType);

            }


            var addMenuRequest = new AddMenuCommand
            {
                RestaurantId = Id,
                Name = requestDto.Name,
                Description = requestDto.Description,
                Price = requestDto.Price,
                Image = imageName

            };

            var result = await _mediator.Send(addMenuRequest);

            if (!result)
            {
                return BadRequest("Error,menu not added!");

            }

            return Ok("Menu added!");


        }


        [HttpPost("update/{Id}")]
        public async Task<IActionResult> UpdateMenu(int Id, [FromForm] updateMenuRequestDto requestDto, [FromForm] IFormFile imageFile)
        {

            var root = _webHostEnvironment.ContentRootPath;
            var path = Path.Combine(root, "wwwroot", "images");
            var imageName = "default.png";

            if (imageFile != null)
            {
                imageName = UploadImageHelper.UploadImage(imageFile, path, imageFile.FileName, imageFile.ContentType);

            }


            var updateRequest = new UpdateMenuCommand
            {
                Id = Id,
                Name = requestDto.Name,
                Price = requestDto.Price,
                Description = requestDto.Description,
                Image = imageName

            };


            var result = await _mediator.Send(updateRequest);

            if (!result)
            {
                return BadRequest("Error,menu not updated");

            }

            return Ok("Menu updated");

        }

    }
}