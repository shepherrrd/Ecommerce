using Ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.RequestHandlers.ActorsRequestHandlers
{
    public class DeleteActor : IRequest<Actors>
    {
        public int Id { get; set; }
    }


    public class DeleteActorHandler : IRequestHandler<DeleteActor, Actors>
    {
        private readonly dbContext _context;
        public DeleteActorHandler(dbContext context)
        {
            _context = context;

        }
        public async Task<Actors> Handle(DeleteActor request, CancellationToken cancellationToken)
        {
            var response = await _context.Actors.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            _context.Remove(response);
           await  _context.SaveChangesAsync();
            return null;
           
        }
    }
}
