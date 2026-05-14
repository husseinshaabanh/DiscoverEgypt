using System.ComponentModel.DataAnnotations;

namespace DiscoverEgypt.Core.Features.Users.DTOs
{
    public class RejectGuideDto
    {
        [Required]
        public string Reason { get; set; }
    }
}