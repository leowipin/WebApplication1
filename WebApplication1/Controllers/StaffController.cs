using System.Transactions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController(ApplicationDbContext context, IMapper mapper, UserManager<User> userManager)
        : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<User> _userManager = userManager;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult> StaffCreate([FromBody] StaffCreationDto staffCreationDto)
        {
            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                var userMapped = _mapper.Map<User>(staffCreationDto);
                var createUserResult = await _userManager.CreateAsync(userMapped, staffCreationDto.Password);
                if (!createUserResult.Succeeded)
                {
                    return BadRequest(createUserResult.Errors);
                }
                var staffMapped = _mapper.Map<Staff>(staffCreationDto);
                staffMapped.User = userMapped;

                await _context.Staffs.AddAsync(staffMapped);
                await _context.SaveChangesAsync();
                
                transaction.Complete();

                var staffDto = _mapper.Map<StaffDto>(staffMapped);

                return CreatedAtAction(nameof(StaffGet), new { id = staffDto.Id }, staffDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StaffDto>> StaffGet(Guid id)
        {
            var staffDto = await _context.Staffs
                .ProjectTo<StaffDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(s=>s.Id == id);

            if (staffDto == null)
            {
                return NotFound();
            }

            return Ok(staffDto);
        }
    }
}