using MediatR;

namespace RatingSystem.PublishedLanguage.Commands
{
    public class UpdateTheUserRating : IRequest
    {
        public int ConferenceId { get; set; }
        public decimal Rating { get; set; }
        public string AttendeeEmail { get; set; }
        public int Id { get; set; }
    }
}
