using Ecommerce.Data.RequestHandlers.ProducerRequestHandler;
using Ecommerce.Models;
using MediatR;

namespace Ecommerce.Data.RequestHandlers.CinemaRequestHandler
{
    public class UpdateCinema : IRequest<Cinema>
    {
        public int Id { get; set; }
        public Cinema cinema { get; set; }
       
    }

    public class UpdateCinemaHandler : IRequestHandler<UpdateCinema, Cinema>
    {
        private readonly dbContext _context;
        public UpdateCinemaHandler(dbContext context)
        {
            _context = context;

        }

       

        public async Task<Cinema> Handle(UpdateCinema updatedCinema, CancellationToken cancellationToken)
        {
             _context.Update(updatedCinema.cinema);
            await _context.SaveChangesAsync(cancellationToken);



            return updatedCinema.cinema;
        }
    }
}
