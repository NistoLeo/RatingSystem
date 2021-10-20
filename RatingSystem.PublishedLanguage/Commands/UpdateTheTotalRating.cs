using MediatR;

namespace RatingSystem.PublishedLanguage.Commands
{
    public class UpdateTheTotalRating : IRequest
    {
        public int ConferenceId { get; set; }
        public decimal Rating { get; set; }
        public int Id { get; set; }
    }
}
