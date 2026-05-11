using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverEgypt.Core.Entities
{
    public class Place : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public Location Location { get; set; }
        public TimeSpan AverageVisitDuration { get; set; }
        public decimal TicketPrice { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<PlanPlace> PlanPlaces { get; set; } = new HashSet<PlanPlace>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    }
}
