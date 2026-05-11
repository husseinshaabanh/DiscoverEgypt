using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiscoverEgypt.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public string TouristId { get; set; }
        public TouristProfile Tourist { get; set; }
        public int PostId { get; set; }
        public CommunityPost CommunityPost { get; set; }
    }
}

