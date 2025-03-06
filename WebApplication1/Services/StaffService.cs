using System.Transactions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Exceptions;
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

            if (!userCreatedResult.Succeeded) throw new UserCreationException(userCreatedResult.Errors);

            var staffMapped = _mapper.Map<Staff>(staffCreationDto);
            staffMapped.User = userMapped;

            await _staffRepository.AddAsync(staffMapped);
            await _staffRepository.SaveChangeAsync();
            transaction.Complete();

            return _mapper.Map<StaffDto>(staffMapped);
        }

        public async Task<StaffDto?> GetStaffByIdAsync(Guid id)
        {
            var query = _staffRepository
                .GetStaffQueryable(id)
                .ProjectTo<StaffDto>((_mapper.ConfigurationProvider));
            return await query.FirstOrDefaultAsync();
        }

    }
}