using Ecommerce.Data.ViewModel;
using Ecommerce.Models;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce.Data.RequestHandlers.MoviesRequestHandlers
{
    public class AddMovie : IRequest<MovieVM>
    {
        public MovieVM data { get; set; }
    }

    public class AddMovieHandler : IRequestHandler<AddMovie, MovieVM>
    {
        private readonly dbContext _context;
        public AddMovieHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<MovieVM> Handle(AddMovie request, CancellationToken cancellationToken)
        {
            var newMovie = new Movie()
            {
                Name = request.data.Name,
                Description = request.data.Description,
                Price = request.data.Price,
                ImageURL = request.data.ImageURL,
                CinemaId = request.data.CinemaId,
                StartDate = request.data.StartDate,
                EndDate = request.data.EndDate,
                MovieCategory = request.data.MovieCategory,
                ProducerId = request.data.ProducerId
            };
           await  _context.Movie.AddAsync(newMovie, cancellationToken);
            await _context.SaveChangesAsync();
            foreach (var actorId in request.data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actor_Movie.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();

            return request.data;
        }


    } 

}

    