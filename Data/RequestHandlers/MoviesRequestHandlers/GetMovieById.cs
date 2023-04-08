using Ecommerce.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Ecommerce.Data.RequestHandlers.MoviesRequestHandlers
{
    public class GetMovieById : IRequest<Movie>
    {
        public int Id { get; set; }
    }

    public class GetMovieByIdValidator : AbstractValidator<GetMovieById> {
        public GetMovieByIdValidator(int id)
        {
            RuleFor(m => m.Id).GreaterThan(0);
        }
    
    }

    public class GetMovieByIdHandler : IRequestHandler<GetMovieById, Movie>
    {
        private readonly dbContext _context;

        public GetMovieByIdHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<Movie> Handle(GetMovieById request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movie.Include(c=> c.Cinema).Include(p => p.Producer).Include(am => am.Actor_Movies).ThenInclude(a => a.Actors).FirstOrDefaultAsync(n => n.Id== request.Id, cancellationToken);

            return movie;
        }
    }
}
