using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Data
{
    public class GetSuggestions
    {
        public class Query : IRequest<List<Model>>
        {
            public int? Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly AfterhillsContext _dbContext;

            public QueryHandler(AfterhillsContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                // TODO: implement logic
                var conferences = _dbContext.Conferences.Where(x => x.Id != request.Id);
                var result = conferences.Select(x => new Model
                {
                    Id = x.Id,
                    Name = x.Name,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    ConferenceTypeId = x.ConferenceTypeId,
                    CategoryId = x.CategoryId,
                    LocationId = x.LocationId

                })
                    .Take(3)
                    .ToList();
                return Task.FromResult(result);
            }
        }

        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ConferenceTypeId { get; set; }
            public int LocationId { get; set; }
            public string OrganizerEmail { get; set; }
            public int CategoryId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
    }
}
