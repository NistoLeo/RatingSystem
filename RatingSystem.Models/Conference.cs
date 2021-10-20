using System;
using System.Collections.Generic;

#nullable disable

namespace RatingSystem.Models
{
    public partial class Conference
    {
        public Conference()
        {
            ConferenceXattendees = new HashSet<ConferenceXattendee>();
            ConferenceXspeakers = new HashSet<ConferenceXspeaker>();
        }

        public int Id { get; set; }
        public int ConferenceTypeId { get; set; }
        public int LocationId { get; set; }
        public string OrganizerEmail { get; set; }
        public int CategoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }

        public virtual DictionaryCategory Category { get; set; }
        public virtual DictionaryConferenceType ConferenceType { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<ConferenceXattendee> ConferenceXattendees { get; set; }
        public virtual ICollection<ConferenceXspeaker> ConferenceXspeakers { get; set; }
    }
}
