using Ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.RequestHandlers.CinemaRequestHandler
{
    public class DeleteCinema : IRequest<Cinema>
    {
        public int Id { get; set; }
    }


    public class DeleteActorHandler : IRequestHandler<DeleteCinema, Cinema>
    {
        private readonly dbContext _context;
        public DeleteActorHandler(dbContext context)
        {
            _context = context;

        }
    

        public async Task<Cinema> Handle(DeleteCinema request, CancellationToken cancellationToken)
        {
             var response = await _context.Cinema.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

             _context.Remove(response);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
