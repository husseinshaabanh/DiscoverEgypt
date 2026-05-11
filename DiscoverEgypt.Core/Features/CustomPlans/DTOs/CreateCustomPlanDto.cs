using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DiscoverEgypt.Core.Features.CustomPlans.DTOs
{
    public class CreateCustomPlanDto
    {
        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        public string? Notes { get; set; }
        public string? Destination { get; set; }
        public IFormFile? Image { get; set; }
    }
}