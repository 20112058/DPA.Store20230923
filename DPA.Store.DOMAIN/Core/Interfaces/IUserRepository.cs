
using DPA.Store.DOMAIN.Core.Entities;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        Task<bool> Insert(User user);

        Task<bool> Delete(int id);
    }
}
