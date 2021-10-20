using MediatR;

namespace RatingSystem.PublishedLanguage.Events
{
    public class TotalRatingUpdated : INotification
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public decimal Rating { get; set; }
    }
}
