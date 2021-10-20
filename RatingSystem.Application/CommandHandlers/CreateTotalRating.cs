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
    public class CreateTotalRating : IRequestHandler<CreateNewTotalRating>
    {

             /*
            CreateTotalRating
            
            assume conference has no existing rating,

            create a new conference rating model,

            add it to the database
             */
        private readonly IMediator _mediator;
        private readonly AfterhillsContext _dbContext;

        public CreateTotalRating(IMediator mediator, AfterhillsContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateNewTotalRating request, CancellationToken cancellationToken)
        {
            var ratingUser = _dbContext.TotalRating.FirstOrDefault(e => e.ConferenceId == request.ConferenceId);
            //aici deja stim but good to attribute it
            

            var newTotalRating = new TotalRating
            {
                Id = request.Id,
                Rating = request.Rating,
                ConferenceId = request.ConferenceId
                
            };

            _dbContext.TotalRating.Add(newTotalRating);
            _dbContext.SaveChanges();


            TotalRatingCreated ec = new TotalRatingCreated
            {
                Id = newTotalRating.Id,
                ConferenceId = newTotalRating.ConferenceId,
                Rating = newTotalRating.Rating
            };

            await _mediator.Publish(ec, cancellationToken);
            return Unit.Value;
        }
    }
}