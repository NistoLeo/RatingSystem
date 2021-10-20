using MediatR;
using RatingSystem.Data;
using RatingSystem.Models;
using RatingSystem.PublishedLanguage.Commands;
using RatingSystem.PublishedLanguage.Events;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Application
{
    public class CreateUserRating : IRequestHandler<CreateNewUserRating>
    {
        private readonly IMediator _mediator;
        private readonly AfterhillsContext _dbContext;

        public CreateUserRating(IMediator mediator, AfterhillsContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateNewUserRating request, CancellationToken cancellationToken)
        {

            /*
            CreateUserRating
            
            verify if the USER already rated the CONFERENCE

            if either USER or CONFERENCE are NULL display RATING ALREADY EXISTS 
                AND do UpdateUserRating

            else continue CreateUserRating
                and add to table
            
            after

            UpdateTotalRating
            */
            var ratingUser = _dbContext.UserRating.FirstOrDefault(
                e => e.AttendeeEmail == request.AttendeeEmail
             && e.ConferenceId == request.ConferenceId);
            if (ratingUser != null)
            {
                //Rating already exists, updating user rating..
                //UpdateUserRating(); //break after
                await mediator.Send(UpdateTheUserRating, cancellationToken); //syntax unreliable
            }

            var rating = new UserRating
            {
                Id = request.Id,
                Rating = request.Rating,
                ConferenceId = request.ConferenceId,
                AttendeeEmail = request.AttendeeEmail
            };

            _dbContext.UserRating.Add(rating);
            CreateTotalRating.(rating); // sau UpdateTotalRating.Handle(rating);
            //sau

            _dbContext.SaveChanges();

            UserRatingCreated ec = new UserRatingCreated
            {
                Id = rating.Id,
                AttendeeEmail = rating.AttendeeEmail,
                Rating = rating.Rating,
                ConferenceId = rating.ConferenceId
            };

            await _mediator.Publish(ec, cancellationToken);
            return Unit.Value;
        }
    }
}