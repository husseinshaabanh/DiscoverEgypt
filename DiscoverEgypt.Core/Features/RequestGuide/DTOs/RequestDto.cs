using DiscoverEgypt.Core.Enums;

namespace DiscoverEgypt.Core.Features.RequestGuide.DTOs
{
    public class RequestDto
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public string Title { get; set; }
        public string TouristName { get; set; }
        public string GuideId { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}