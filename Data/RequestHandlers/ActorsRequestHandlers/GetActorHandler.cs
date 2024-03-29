﻿using Ecommerce.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.RequestHandlers.ActorsRequestHandlers
{
    public class GetActors : IRequest<IEnumerable<Actors>> { }
    public class GetProducerHandler : IRequestHandler<GetActors, IEnumerable<Actors>>
    {
        private readonly dbContext _context;
        public GetProducerHandler(dbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Actors>> Handle(GetActors request, CancellationToken cancellationToken)
        {
          return await  _context.Actors.ToListAsync(cancellationToken);
        }
    }
}
