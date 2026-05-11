using DiscoverEgypt.Core.Features.Users.DTOs;

namespace DiscoverEgypt.Core.Features.Users.Interfaces
{
    public interface IUserService
    {
        Task<UserProfileDto> GetCurrentUserAsync(string userId);
        Task<UserProfileDto> GetUserByIdAsync(string id);
        Task<List<UserProfileDto>> GetAllUsersAsync();
        Task UpdateMyProfileAsync(string userId, UpdateUserDto dto);
        Task DeleteMyProfileAsync(string userId);
        Task DeleteUserAsync(string id);
        Task ChangePasswordAsync(string userId, ChangePasswordDto dto);
        Task<int> GetUserPointsAsync(string userId);
    }
}