namespace DiscoverEgypt.Core.Features.Places.DTOs
{
    public class PlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public decimal TicketPrice { get; set; }
        public string CategoryName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
    }
}