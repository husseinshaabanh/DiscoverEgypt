using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DiscoverEgypt.Core.Features.Users.DTOs;
using DiscoverEgypt.Core.Features.Users.Interfaces;

namespace DiscoverEgypt.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>Retrieves the profile of the currently authenticated user.</summary>
        [HttpGet("my-profile")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var user = await _userService.GetCurrentUserAsync(userId);
            return Ok(user);
        }

        /// <summary>Returns the points balance of the authenticated tourist.</summary>
        [HttpGet("points")]
        public async Task<IActionResult> GetPoints()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var points = await _userService.GetUserPointsAsync(userId);
            return Ok(new { points });
        }

        /// <summary>Updates the profile of the currently authenticated user.</summary>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMyProfile([FromBody] UpdateUserDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _userService.UpdateMyProfileAsync(userId, dto);
            return Ok(new { message = "Profile updated successfully" });
        }

        /// <summary>Changes the password of the currently authenticated user.</summary>
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _userService.ChangePasswordAsync(userId, dto);
            return Ok(new { message = "Password changed successfully" });
        }

        /// <summary>Permanently deletes the account of the currently authenticated user.</summary>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMyProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _userService.DeleteMyProfileAsync(userId);
            return Ok(new { message = "Account deleted successfully" });
        }

        // ─── Admin Endpoints ───

        /// <summary>Retrieves all registered users. Admin only.</summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>Retrieves a specific user by ID. Admin only.</summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        /// <summary>Deletes a specific user by ID. Admin only.</summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}