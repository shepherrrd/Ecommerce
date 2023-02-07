using Ecommerce.Models;
using MediatR;

namespace Ecommerce.Data.RequestHandlers.ActorsRequestHandlers
{
    public class UpdateActor : IRequest<Actors>
    {
        public int Id { get; set; }
        public Actors actors { get; set; }
       
    }

    public class UpdateActorHandler : IRequestHandler<UpdateActor, Actors>
    {
        private readonly dbContext _context;
        public UpdateActorHandler(dbContext context)
        {
            _context = context;

        }
        public async Task<Actors> Handle(UpdateActor updatedActor, CancellationToken cancellationToken)
        {
            _context.Update(updatedActor.actors);
            await  _context.SaveChangesAsync(cancellationToken);

           

            return updatedActor.actors;

            

           
            
        }
    }
}
