using System.ComponentModel.DataAnnotations;

namespace DiscoverEgypt.Core.Features.RequestGuide.DTOs
{
    public class CreateRequestDto
    {
        [Required]
        public int TripId { get; set; }

        [Required]
        public string GuideId { get; set; }
    }
}