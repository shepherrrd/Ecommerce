﻿using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly dbContext _context;
        public ActorsService(dbContext context) { _context = context; }

        public void Add(Actors actor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actors>> GetAll()
        {
           
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public Actors GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Actors Update(int id, Actors actor)
        {
            throw new NotImplementedException();
        }
    }
}
