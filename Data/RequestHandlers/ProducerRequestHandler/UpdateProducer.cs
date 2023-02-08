using Ecommerce.Data.RequestHandlers.ProducerRequestHandler;
using Ecommerce.Models;
using MediatR;

namespace Ecommerce.Data.RequestHandlers.ProducerRequestHandler
{
    public class UpdateProducer : IRequest<Producer>
    {
        public int Id { get; set; }
        public Producer producer { get; set; }
       
    }

    public class UpdateProducerHandler : IRequestHandler<UpdateProducer, Producer>
    {
        private readonly dbContext _context;
        public UpdateProducerHandler(dbContext context)
        {
            _context = context;

        }

        public async Task<Producer> Handle(UpdateProducer updatedProducer, CancellationToken cancellationToken)
        {
            _context.Update(updatedProducer.producer);
            await _context.SaveChangesAsync(cancellationToken);



            return updatedProducer.producer;
        }
    }
}
