using System.ComponentModel.DataAnnotations;

namespace DiscoverEgypt.Core.Features.Payment.DTOs
{
    public class PayDto
    {
        [Required]
        public int BookingId { get; set; }
    }
}