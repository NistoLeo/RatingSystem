using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingSystem.Models
{
    public class UserRating
    {
        public int Id { get; set; }
        public string AttendeeEmail { get; set; }
        public decimal Rating { get; set; }
        public int ConferenceId { get; set; }
    }
}
