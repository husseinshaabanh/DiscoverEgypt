using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Exceptions;
using DiscoverEgypt.Core.Features.Users.DTOs;
using DiscoverEgypt.Core.Features.Users.Interfaces;
using DiscoverEgypt.Repository.Data.DBContext;

namespace DiscoverEgypt.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserProfileDto> GetCurrentUserAsync(string userId)
        {
            var user = await _userManager.Users
                .Include(u => u.Nationality)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                throw new NotFoundException("User not found");

            var roles = await _userManager.GetRolesAsync(user);
            var dto = _mapper.Map<UserProfileDto>(user);
            dto.Roles = roles.ToList();

            return dto;
        }

        public async Task<UserProfileDto> GetUserByIdAsync(string id)
        {
            var user = await _userManager.Users
                .Include(u => u.Nationality)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new NotFoundException("User not found");

            var roles = await _userManager.GetRolesAsync(user);
            var dto = _mapper.Map<UserProfileDto>(user);
            dto.Roles = roles.ToList();

            return dto;
        }

        public async Task<List<UserProfileDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users
                .Include(u => u.Nationality)
                .ToListAsync();

            var result = new List<UserProfileDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var dto = _mapper.Map<UserProfileDto>(user);
                dto.Roles = roles.ToList();
                result.Add(dto);
            }

            return result;
        }

        public async Task UpdateMyProfileAsync(string userId, UpdateUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new NotFoundException("User not found");

            user.FirstName = dto.FirstName ?? user.FirstName;
            user.LastName = dto.LastName ?? user.LastName;
            user.PhoneNumber = dto.PhoneNumber ?? user.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                throw new ValidationException(
                    string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task DeleteMyProfileAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new NotFoundException("User not found");

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                throw new ValidationException("Failed to delete account");
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new NotFoundException("User not found");

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                throw new ValidationException("Failed to delete user");
        }

        public async Task ChangePasswordAsync(string userId, ChangePasswordDto dto)
        {
            if (dto.NewPassword != dto.ConfirmNewPassword)
                throw new ValidationException("New passwords don't match");

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new NotFoundException("User not found");

            var result = await _userManager.ChangePasswordAsync(
                user, dto.CurrentPassword, dto.NewPassword);

            if (!result.Succeeded)
                throw new ValidationException(
                    string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task<int> GetUserPointsAsync(string userId)
        {
            var tourist = await _context.Tourists
                .FirstOrDefaultAsync(t => t.UserId == userId);

            if (tourist == null)
                throw new NotFoundException("Tourist profile not found");

            return tourist.Points;
        }
    }
}