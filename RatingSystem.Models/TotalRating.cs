using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingSystem.Models
{
    public class TotalRating
    {
        public int Id { get; set; }
        public decimal Rating { get; set; }
        public int ConferenceId { get; set; }
    }
}
