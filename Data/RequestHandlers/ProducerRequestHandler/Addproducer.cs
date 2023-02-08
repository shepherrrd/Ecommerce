using Ecommerce.Models;
using MediatR;

namespace Ecommerce.Data.RequestHandlers.ProducerRequestHandler
{
    public class AddProucer : IRequest<Producer>
    {
        public Producer producer;
    }
    
    public class AddproducerHandler : IRequestHandler<AddProucer, Producer>
    {
        private readonly dbContext _context;
        public AddproducerHandler(dbContext context)
        {
            _context = context;

        }

        public async Task<Producer> Handle(AddProucer request, CancellationToken cancellationToken)
        {
            await _context.Producer.AddAsync(request.producer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return request.producer;
        }

       
    }
}
