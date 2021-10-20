using System;
using System.Collections.Generic;

#nullable disable

namespace RatingSystem.Models
{
    public partial class ConferenceXspeaker
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public int SpeakerId { get; set; }
        public bool? IsMainSpeaker { get; set; }

        public virtual Conference Conference { get; set; }
        public virtual Speaker Speaker { get; set; }
    }
}
