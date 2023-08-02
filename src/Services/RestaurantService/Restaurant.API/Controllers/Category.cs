using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.API.Dtos;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Category : ControllerBase
    {

        public Category()
        {


        }



        [HttpPost]
        [Route("add")]
        public Task<IActionResult> AddCategory([FromBody] CategoryDto category)
        {
            throw new NotImplementedException();
        }
    }
}