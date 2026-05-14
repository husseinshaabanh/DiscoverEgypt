using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DiscoverEgypt.Core.Features.Community.DTOs;
using DiscoverEgypt.Core.Features.Community.Interfaces;

namespace DiscoverEgypt.API.Controllers
{
    [ApiController]
    [Route("api/community")]
    [Authorize]
    public class CommunityController : ControllerBase
    {
        private readonly ICommunityService _service;

        public CommunityController(ICommunityService service)
        {
            _service = service;
        }

        // ─── Posts ───

        [HttpGet]
        public async Task<IActionResult> GetFeed(
            [FromQuery] int page = 1,
            [FromQuery] int size = 20)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _service.GetFeedAsync(userId, page, size);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _service.GetPostByIdAsync(id, userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] CreatePostDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _service.CreatePostAsync(userId, dto);
            return StatusCode(201, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromForm] UpdatePostDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _service.UpdatePostAsync(id, userId, dto);
            return Ok(new { message = "Post updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _service.DeletePostAsync(id, userId);
            return Ok(new { message = "Post deleted successfully" });
        }

        [HttpPost("{id}/images")]
        public async Task<IActionResult> AddPostImages(int id, [FromForm] List<IFormFile> images)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _service.AddPostImagesAsync(id, userId, images);
            return Ok(new { message = "Images added successfully" });
        }

        [HttpDelete("{id}/images/{imageId}")]
        public async Task<IActionResult> DeletePostImage(int id, int imageId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _service.DeletePostImageAsync(id, userId, imageId);
            return Ok(new { message = "Image deleted successfully" });
        }

        // ─── Post Likes ───

        [HttpPost("{id}/like")]
        public async Task<IActionResult> LikePost(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _service.LikePostAsync(id, userId);
            return Ok(new { message = "Post liked" });
        }

        [HttpDelete("{id}/like")]
        public async Task<IActionResult> UnlikePost(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _service.UnlikePostAsync(id, userId);
            return Ok(new { message = "Post unliked" });
        }

        // ─── Comments ───

        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetComments(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _service.GetCommentsAsync(id, userId);
            return Ok(result);
        }

        [HttpPost("comments")]
        public async Task<IActionResult> CreateComment([FromForm] CreateCommentDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await _service.CreateCommentAsync(userId, dto);
            return StatusCode(201, result);
        }

        [HttpPut("comments/{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromForm] UpdateCommentDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _service.UpdateCommentAsync(id, userId, dto);
            return Ok(new { message = "Comment updated successfully" });
        }

        [HttpDelete("comments/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _service.DeleteCommentAsync(id, userId);
            return Ok(new { message = "Comment deleted successfully" });
        }

        // ─── Comment Likes ───

        [HttpPost("comments/{id}/like")]
        public async Task<IActionResult> LikeComment(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _service.LikeCommentAsync(id, userId);
            return Ok(new { message = "Comment liked" });
        }

        [HttpDelete("comments/{id}/like")]
        public async Task<IActionResult> UnlikeComment(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _service.UnlikeCommentAsync(id, userId);
            return Ok(new { message = "Comment unliked" });
        }
    }
}