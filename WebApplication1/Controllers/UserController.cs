using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UserController(ApplicationDbContext dbContext) : ControllerBase
    {
        private ApplicationDbContext _dbContext = dbContext;

        //[HttpPost]
        //public Task<IActionResult> CreateUser(User user)
        //{

        //    return Ok("usuario creado con exito");
        //}

    } 
}