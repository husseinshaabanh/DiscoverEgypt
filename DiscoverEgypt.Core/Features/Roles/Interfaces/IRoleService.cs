using DiscoverEgypt.Core.Features.Roles.DTOs;

namespace DiscoverEgypt.Core.Features.Roles.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<string>> GetRolesAsync();
        Task CreateRoleAsync(CreateRoleDto dto);
        Task DeleteRoleAsync(string roleId);
        Task<IList<string>> GetUserRolesAsync(string userId);
        Task AssignRoleToUserAsync(string userId, string roleName);
        Task RemoveRoleFromUserAsync(string userId, string roleName);
    }
}