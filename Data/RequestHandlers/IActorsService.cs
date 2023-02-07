using Ecommerce.Models;

namespace Ecommerce.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actors>> GetAll();
        Actors GetById(int id);

        void Add(Actors actor);

        Actors Update(int id ,Actors actor);
        void Delete(int id);   
    }
}
