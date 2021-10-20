using System;
using System.Collections.Generic;

#nullable disable

namespace RatingSystem.Models
{
    public partial class ConferenceXattendee
    {
        public int Id { get; set; }
        public string AttendeeEmail { get; set; }
        public int ConferenceId { get; set; }
        public int StatusId { get; set; }

        public virtual Conference Conference { get; set; }
        public virtual DictionaryStatus Status { get; set; }
    }
}
