using Ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.RequestHandlers.ProducerRequestHandler
{
    public class DeleteProducer : IRequest<Producer>
    {
        public int Id { get; set; }
    }


    public class DeleteActorHandler : IRequestHandler<DeleteProducer, Producer>
    {
        private readonly dbContext _context;
        public DeleteActorHandler(dbContext context)
        {
            _context = context;

        }
       

        public async Task<Producer> Handle(DeleteProducer request, CancellationToken cancellationToken)
        {
            var response = await _context.Producer.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

             _context.Remove(response);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
