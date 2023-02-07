using Ecommerce.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace Ecommerce.Data.RequestHandlers.ActorsRequestHandlers
{

    public class GetActorById : IRequest<Actors>
    {
        public int Id { get; set; }
    }
    public class GetActorByIdValidator : AbstractValidator<GetActorById>
    {
        public GetActorByIdValidator(int id)
        {
            RuleFor(m => m.Id).GreaterThan(0);
        }
    }

    public class GetActorByIdHandler : IRequestHandler<GetActorById, Actors>
    {

        private readonly dbContext _context;

        public GetActorByIdHandler(dbContext context)
        {
            _context = context;
        }

        public async Task<Actors> Handle(GetActorById request, CancellationToken cancellationToken)
        {
            var response = await _context.Actors.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            return response;

            
        }
    }
}
