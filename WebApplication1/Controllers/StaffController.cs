using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Exceptions;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController(IStaffService staffService) : ControllerBase
    {
        private readonly IStaffService _staffService = staffService;

        [HttpPost]
        public async Task<ActionResult> StaffCreate([FromBody] StaffCreationDto staffCreationDto)
        {
            try
            {
                var staffDto = await _staffService.CreateStaffByIdAsync(staffCreationDto);
                return CreatedAtAction(nameof(StaffGet), new { id = staffDto.Id }, staffDto);
            }
            catch (UserCreationException ex)
            {
                return BadRequest(new { error = ex.Message, details = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StaffDto>> StaffGet(Guid id)
        {
            var staffDto = await _staffService.GetStaffByIdAsync(id);
            if (staffDto == null) return NotFound();
            return Ok(staffDto);
        }
    }
}