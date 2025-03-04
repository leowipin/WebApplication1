using System.Transactions;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController(ApplicationDbContext context, UserManager<User> userManager, IMapper mapper)
        : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<User> _userManager = userManager;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult> CustomerPost([FromBody] CustomerCreationDto customer)
        {
            //using var transaction = await _context.Database.BeginTransactionAsync();
            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                var user = _mapper.Map<User>(customer);
                var createUserResult = await _userManager.CreateAsync(user, customer.Password);
                if (!createUserResult.Succeeded)
                {
                    return BadRequest(createUserResult.Errors);
                }
                var mapCustomerResult = _mapper.Map<Customer>(customer);
                mapCustomerResult.CustomerType = Enums.CustomerTypes.Regular;
                mapCustomerResult.Id = user.Id;
                mapCustomerResult.User = user;

                _context.Customers.Add(mapCustomerResult);
                await _context.SaveChangesAsync();
                //await transaction.CommitAsync();

                var customerDto = _mapper.Map<CustomerDto>(mapCustomerResult);

                transaction.Complete();

                return CreatedAtAction(nameof(CustomerGet), new {id = customerDto.Id} ,customerDto);
            }
            catch (Exception ex)
            {
                //await transaction.RollbackAsync();
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> CustomerGet(Guid id)
        {
            var customer = await _context.Customers
                .Include(c=>c.User)
                .FirstOrDefaultAsync(c=>c.Id==id);

            if (customer == null)
            {
                return NotFound();
            }

            var customerDto = _mapper.Map<CustomerDto>(customer);

            return Ok(customerDto);
        }
    }
}