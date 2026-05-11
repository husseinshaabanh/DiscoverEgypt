using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Linq;

namespace DiscoverEgypt.Core.Entities
{
    public class CommunityPost : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string TouristId { get; set; }
        public TouristProfile Tourist { get; set; }
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}

