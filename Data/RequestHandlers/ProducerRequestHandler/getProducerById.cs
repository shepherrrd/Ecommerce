using Ecommerce.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Ecommerce.Data.RequestHandlers.ActorsRequestHandlers;

namespace Ecommerce.Data.RequestHandlers.ProducerRequestHandler
{

    public class GetProducerById : IRequest<Producer>
    {
        public int Id { get; set; }
    }
    public class GetProducerByIdValidator : AbstractValidator<GetProducerById>
    {
        public GetProducerByIdValidator(int id)
        {
            RuleFor(m => m.Id).GreaterThan(0);
        }
    }

    public class GetProducerByIdHandler : IRequestHandler<GetProducerById, Producer>
    {
        

        private readonly dbContext _context;

        public GetProducerByIdHandler(dbContext context)
        {
            _context = context;
        }

        

        public  async Task<Producer> Handle(GetProducerById request, CancellationToken cancellationToken)
        {
            var response = await _context.Producer.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            return response;
        }
    }
}
