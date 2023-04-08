using Ecommerce.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.RequestHandlers.MoviesRequestHandlers
{
    public class GetMovies : IRequest<IEnumerable<Movie>>
    {
    }

    public class GetMoviesHandler : IRequestHandler<GetMovies, IEnumerable<Movie>>
    {
        private readonly dbContext _context;
        public GetMoviesHandler(dbContext context)
        {
            _context = context;
        }

       

        async Task<IEnumerable<Movie>> IRequestHandler<GetMovies, IEnumerable<Movie>>.Handle(GetMovies request, CancellationToken cancellationToken)
        {
            return await _context.Movie.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync(cancellationToken);

        }
    }
}
