using System.ComponentModel.DataAnnotations;

namespace DiscoverEgypt.Core.Features.Places.DTOs
{
    public class CreatePlaceDto
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        public TimeSpan AverageVisitDuration { get; set; }

        [Range(0, double.MaxValue)]
        public decimal TicketPrice { get; set; }

        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}