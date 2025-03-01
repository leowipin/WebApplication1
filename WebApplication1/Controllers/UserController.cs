using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        
        //[HttpPost]
        //public Task<IActionResult> CreateUser(User user)
        //{

        //    return Ok("usuario creado con exito");
        //}

    } 
}