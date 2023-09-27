
using DPA.Store.DOMAIN.Core.Entities;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        Task<bool> Insert(User user);

        Task<bool> Validacion(string correo, string contrasena);

        Task<bool> Delete(int id);
    }
}
