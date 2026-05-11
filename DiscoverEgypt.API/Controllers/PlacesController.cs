using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DiscoverEgypt.Core.Features.Places.DTOs;
using DiscoverEgypt.Core.Features.Places.Interfaces;

namespace DiscoverEgypt.API.Controllers
{
    [ApiController]
    [Route("api/places")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        /// <summary>Retrieves all places, optionally filtered by city or category.</summary>
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? city,
            [FromQuery] int? categoryId)
        {
            var result = await _placeService.GetAllAsync(city, categoryId);
            return Ok(result);
        }

        /// <summary>Retrieves a specific place by ID.</summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _placeService.GetByIdAsync(id);
            return Ok(result);
        }

        /// <summary>Creates a new place. Admin only.</summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreatePlaceDto dto)
        {
            var result = await _placeService.CreateAsync(dto);
            return StatusCode(201, result);
        }

        /// <summary>Updates an existing place. Admin only.</summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePlaceDto dto)
        {
            await _placeService.UpdateAsync(id, dto);
            return Ok(new { message = "Place updated successfully" });
        }

        /// <summary>Deletes a place. Admin only.</summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _placeService.DeleteAsync(id);
            return Ok(new { message = "Place deleted successfully" });
        }
    }
}