using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverEgypt.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Place> Places { get; set; } = new HashSet<Place>();
    }
}
