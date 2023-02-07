using Ecommerce.Models;
using MediatR;

namespace Ecommerce.Data.RequestHandlers.ActorsRequestHandlers
{
    
    public class AddActorHandler : IRequestHandler<Actors, Unit>
    {
        private readonly dbContext _context;
        public AddActorHandler(dbContext context)
        {
            _context = context;

        }
         async Task<Unit> IRequestHandler<Actors, Unit>.Handle(Actors actor, CancellationToken cancellationToken)
        {
            await _context.Actors.AddAsync(actor, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
