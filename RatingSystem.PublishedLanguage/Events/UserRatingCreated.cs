using MediatR;

namespace RatingSystem.PublishedLanguage.Events
{
    public class UserRatingCreated : INotification
    {
        public string AttendeeEmail { get; set; }
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public decimal Rating { get; set; }
    }
}
