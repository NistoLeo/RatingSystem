using System;
using System.Collections.Generic;

#nullable disable

namespace RatingSystem.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string LogEvent { get; set; }
        public Guid? CorrelationId { get; set; }
    }
}
