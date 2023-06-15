using Gerenciador.Models;

namespace Gerenciador.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<List<User>> GetByName(string name);
        Task<User> Post(User user);
        Task<User> Put(int id, User user);
        Task<User> Delete(int id);
    }
}
