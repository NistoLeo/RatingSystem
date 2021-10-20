using MediatR;
using RatingSystem.Data;
using RatingSystem.Models;
using RatingSystem.PublishedLanguage.Commands;
using RatingSystem.PublishedLanguage.Events;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Application.CommandHandlers
{
    public class UpdateUserRating
    {
        
        private readonly IMediator _mediator;
        private readonly AfterhillsContext _dbContext;

        public UpdateUserRating(IMediator mediator, AfterhillsContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateTheUserRating request, CancellationToken cancellationToken)
        {

         /* UpdateUserRating

         assume the USER already rated the CONFERENCE
         add user rating object to database

         after

         UpdateTotalRating
         */

            var ratingUser = _dbContext.UserRating.FirstOrDefault(
                e => e.AttendeeEmail == request.AttendeeEmail
             && e.ConferenceId == request.ConferenceId);    //checku asta e facut la createUserRating, we do it again 
                                                            //trimit ratingul catre updateTotalRating si CreateTotalRating

            ratingUser.Id = request.Id;
            ratingUser.Rating = request.Rating;
            ratingUser.ConferenceId = request.ConferenceId;
            ratingUser.AttendeeEmail = request.AttendeeEmail;
            //_dbContext.UserRating.Update(rating); dont work
            UpdateTotalRating.(); // aici trebuie sa trimit parametrul ratingUser.Rating unde va fi folosit in recalculare
            _dbContext.SaveChanges();

            UserRatingUpdated ec = new UserRatingUpdated
            {
                Id = ratingUser.Id,
                AttendeeEmail = ratingUser.AttendeeEmail,
                Rating = ratingUser.Rating,
                ConferenceId = ratingUser.ConferenceId
            };

            await _mediator.Publish(ec, cancellationToken);
            return Unit.Value;
        }


    }
}
