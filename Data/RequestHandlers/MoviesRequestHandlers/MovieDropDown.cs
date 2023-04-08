using eTickets.Data.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.RequestHandlers.MoviesRequestHandlers
{
    public class MovieDropDown : IRequest<NewMovieDropdownsVM>
    {
    }
    public class MovieDropDownHandler : IRequestHandler<MovieDropDown, NewMovieDropdownsVM>
    {

        private readonly dbContext _context;

        public MovieDropDownHandler(dbContext context)
        {
            _context = context;
        }
       

        async Task<NewMovieDropdownsVM> IRequestHandler<MovieDropDown, NewMovieDropdownsVM>.Handle(MovieDropDown request, CancellationToken cancellationToken)
        {
            var response = new NewMovieDropdownsVM();

            response.Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync();
            response.Cinemas = await _context.Cinema.OrderBy(n => n.Name).ToListAsync();
            response.Producers = await _context.Producer.OrderBy(n => n.FullName).ToListAsync();

            return response;
        }
    }
}
