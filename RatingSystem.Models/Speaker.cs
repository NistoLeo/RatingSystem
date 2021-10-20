using System;
using System.Collections.Generic;

#nullable disable

namespace RatingSystem.Models
{
    public partial class Speaker
    {
        public Speaker()
        {
            ConferenceXspeakers = new HashSet<ConferenceXspeaker>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public decimal? Rating { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<ConferenceXspeaker> ConferenceXspeakers { get; set; }
    }
}
