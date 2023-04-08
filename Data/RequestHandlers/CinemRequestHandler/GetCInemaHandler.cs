using Ecommerce.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.RequestHandlers.CinemaRequestHandler
{
    public class GetCinema : IRequest<IEnumerable<Cinema>> { }
    public class GetCinemaHandler : IRequestHandler<GetCinema, IEnumerable<Cinema>>
    {
        private readonly dbContext _context;
        public GetCinemaHandler(dbContext context)
        {
            _context = context;

        }

        

        public async Task<IEnumerable<Cinema>> Handle(GetCinema request, CancellationToken cancellationToken)
        {
            return await  _context.Cinema.ToListAsync(cancellationToken);
        }
    }
}
