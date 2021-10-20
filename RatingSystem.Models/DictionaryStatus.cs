using System;
using System.Collections.Generic;

#nullable disable

namespace RatingSystem.Models
{
    public partial class DictionaryStatus
    {
        public DictionaryStatus()
        {
            ConferenceXattendees = new HashSet<ConferenceXattendee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<ConferenceXattendee> ConferenceXattendees { get; set; }
    }
}
