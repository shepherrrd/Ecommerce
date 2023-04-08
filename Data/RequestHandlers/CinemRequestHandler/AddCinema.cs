using Ecommerce.Models;
using MediatR;

namespace Ecommerce.Data.RequestHandlers.CinemaRequestHandler
{
    public class AddCinema : IRequest<Cinema>
    {
        public Cinema cinema;
    }
    
    public class AddproducerHandler : IRequestHandler<AddCinema, Cinema>
    {
        private readonly dbContext _context;
        public AddproducerHandler(dbContext context)
        {
            _context = context;

        }

    

        public async Task<Cinema> Handle(AddCinema request, CancellationToken cancellationToken)
        {
            await _context.Cinema.AddAsync(request.cinema, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return request.cinema;
        }
    }
}
