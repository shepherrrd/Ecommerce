using Ecommerce.Models;
using MediatR;

namespace Ecommerce.Data.RequestHandlers.ActorsRequestHandlers
{
    public class AddActor : IRequest<Actors>
    {
        public Actors actors { get; set; }
    }
    public class AddActorHandler : IRequestHandler<AddActor, Actors>
    {
        private readonly dbContext _context;
        public AddActorHandler(dbContext context)
        {
            _context = context;

        }

        public async Task<Actors> Handle(AddActor actor, CancellationToken cancellationToken)
        {
            await _context.Actors.AddAsync(actor.actors, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return actor.actors;
        }

       
    }
}
