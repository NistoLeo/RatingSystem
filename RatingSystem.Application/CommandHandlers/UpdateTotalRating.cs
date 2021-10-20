using MediatR;
using RatingSystem.Data;
using RatingSystem.Models;
using RatingSystem.PublishedLanguage.Commands;
using RatingSystem.PublishedLanguage.Events;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Application.CommandHandlers
{
    class UpdateTotalRating
    {
        /*
        UpdateTotalRating

        verify if the CONFERENCE already has at least one RATING

        if CONFERENCERATING exists aka if ConferenceID in TotalRating exists
            do UpdateTotalRating

        else 
            do CreateTotalRating

        and add to table                     
         */


        private readonly IMediator _mediator;
        private readonly AfterhillsContext _dbContext;

        public UpdateTotalRating(IMediator mediator, AfterhillsContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateTheTotalRating request, CancellationToken cancellationToken)
        {
            var conferenceRating = _dbContext.TotalRating.FirstOrDefault(e => e.ConferenceId == request.ConferenceId);
            if (conferenceRating == null)
            {
                //This conference has no rating, creating.. //add create functionality
                CreateTotalRating();    //ii dau acelasi parametru user.Rating primit de la update/createUserRating
                //break after

            }

            var calculatedRating = 0; //aici calculez cu un foreach new average rating

            conferenceRating.Rating = calculatedRating; //aici se atribuie noul total rating calculat cu foreach mai sus

            _dbContext.SaveChanges();



            TotalRatingCreated ec = new TotalRatingCreated
            {
                Id = conferenceRating.Id,
                ConferenceId = conferenceRating.ConferenceId,
                Rating = conferenceRating.Rating
            };

            await _mediator.Publish(ec, cancellationToken);
            return Unit.Value;
        }
    }
}
