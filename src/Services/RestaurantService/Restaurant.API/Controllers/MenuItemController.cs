using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.MenuItem;
using Domain.Models.MenuItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuItemController : ControllerBase
    {
        public IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MenuItemController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _mediator = mediator;

        }



        [HttpPost("add")]
        public async Task<IActionResult> AddMenuItem([FromForm] AddMenuItemRequestDto requestDto, [FromForm] IFormFile imageFile)
        {

            var root = _webHostEnvironment.WebRootPath;
            var path = Path.Combine(root, "images", "menuitems");
            var imageName = "images/menuitems/default.png";

            if (imageFile != null)
            {
                imageName = Util.UploadImage.UploadImageHelper.UploadImage(imageFile, path, imageFile.FileName, imageFile.ContentType);

            }

            var pathToImage = Path.Combine(path, imageName);



            var request = new AddMenuItemCommand
            {
                CategoryId = requestDto.CategoryId,
                MenuId = requestDto.MenuId,
                Name = requestDto.Name,
                Description = requestDto.Description,
                Price = requestDto.Price,
                Image = pathToImage

            };

            var result = await _mediator.Send(request);
            if (!result)
            {
                return BadRequest("Error,menuitem not added!");

            }

            return Ok("Menuitem added");

        }


        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteMenuItem(int Id)
        {
            var deleteRequest = new DeleteMenuItemCommand
            {
                Id = Id

            };

            var result = await _mediator.Send(deleteRequest);
            if (!result)
            {
                return BadRequest("Error,menuitem not deleted!");

            }

            return Ok("menuitem deleted!");



        }











    }
}