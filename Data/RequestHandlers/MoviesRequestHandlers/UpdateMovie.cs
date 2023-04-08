using Ecommerce.Data.ViewModel;
using Ecommerce.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.RequestHandlers.MoviesRequestHandlers
{
    public class UpdateMovie : IRequest<MovieVM>
    {
        public MovieVM data { get; set; }

    }

    public class UpdateMovieHandler : IRequestHandler<UpdateMovie, MovieVM>
    {
        private readonly dbContext _context;
        public UpdateMovieHandler(dbContext context)
        {
            _context = context;
        }

        public async Task<MovieVM> Handle(UpdateMovie request, CancellationToken cancellationToken)
        {
            var dbMovie = await _context.Movie.FirstOrDefaultAsync(n => n.Id ==request.data.Id);

            if (dbMovie != null) {

                dbMovie.Name = request.data.Name;
                dbMovie.Description = request.data.Description;
                dbMovie.Price = request.data.Price;
                dbMovie.ImageURL = request.data.ImageURL;
                dbMovie.CinemaId = request.data.CinemaId;
                dbMovie.StartDate = request.data.StartDate;
                dbMovie.EndDate = request.data.EndDate;
                dbMovie.MovieCategory = request.data.MovieCategory;
                    dbMovie.ProducerId = request.data.ProducerId;
              var existingActorsDB = _context.Actor_Movie.Where(n => n.MovieId == request.data.Id).ToList();
                _context.Actor_Movie.RemoveRange(existingActorsDB);
                await _context.SaveChangesAsync();
                foreach (var actorId in request.data.ActorIds)
                {
                    var newActorMovie = new Actor_Movie()
                    {
                        MovieId = request.data.Id,
                        ActorId = actorId
                    };
                    await _context.Actor_Movie.AddAsync(newActorMovie);
                }
                await _context.SaveChangesAsync();

                return request.data;
            }
            return request.data;

        }
           
    }
}
