using System;
using System.Collections.Generic;

#nullable disable

namespace RatingSystem.Models
{
    public partial class DictionaryCounty
    {
        public DictionaryCounty()
        {
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
