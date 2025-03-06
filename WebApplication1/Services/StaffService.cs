using System.Transactions;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Dtos;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StaffService(UserManager<User> userManager, IMapper mapper, IStaffRepository staffRepository)
        : IStaffService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IMapper _mapper = mapper;
        private readonly IStaffRepository _staffRepository = staffRepository;

        public async Task<StaffDto> CreateStaffByIdAsync(StaffCreationDto staffCreationDto)
        {
            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            var userMapped = _mapper.Map<User>(staffCreationDto);
            var userCreatedResult = await _userManager.CreateAsync(userMapped, staffCreationDto.Password);
            if (!userCreatedResult.Succeeded)
            {
                return BadRequest(); //CONTINUAR...
            }
        }

    }
}