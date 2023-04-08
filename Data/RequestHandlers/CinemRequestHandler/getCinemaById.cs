using Ecommerce.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Ecommerce.Data.RequestHandlers.ActorsRequestHandlers;

namespace Ecommerce.Data.RequestHandlers.CinemaRequestHandler
{

    public class GetCinemaById: IRequest<Cinema>
    {
        public int Id { get; set; }
    }
    public class GetCinemaByIdValidator : AbstractValidator<GetCinemaById>
    {
        public GetCinemaByIdValidator(int id)
        {
            RuleFor(m => m.Id).GreaterThan(0);
        }
    }

    public class GetProducerByIdHandler : IRequestHandler<GetCinemaById, Cinema>
    {
        

        private readonly dbContext _context;

        public GetProducerByIdHandler(dbContext context)
        {
            _context = context;
        }

    

        public async Task<Cinema> Handle(GetCinemaById request, CancellationToken cancellationToken)
        {
             var response = await _context.Cinema.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            return response;
        }
    }
}
