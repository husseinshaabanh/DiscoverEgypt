using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverEgypt.Core.Entities
{
    public class Review : BaseEntity
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string TouristId { get; set; }
        public TouristProfile Tourist { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        public string GuideId { get; set; }
        public GuideProfile Guide { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
