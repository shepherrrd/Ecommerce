using Ecommerce.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.RequestHandlers.ProducerRequestHandler
{
    public class GetProducer : IRequest<IEnumerable<Producer>> { }
    public class GetProducerHandler : IRequestHandler<GetProducer, IEnumerable<Producer>>
    {
        private readonly dbContext _context;
        public GetProducerHandler(dbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Producer>> Handle(GetProducer request, CancellationToken cancellationToken)
        {
          return await  _context.Producer.ToListAsync(cancellationToken);
        }
    }
}
