using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using DPA.Store.DOMAIN.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _dbContext;
        
        public UserRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.User.ToListAsync();
        }
        public async Task<bool> Insert(User user)
        {
            await _dbContext.User.AddAsync(user);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Validacion(string correo, string contrasena)
        {
            var validacion = await _dbContext.User.Where(x => x.Email == correo && x.Password == contrasena).FirstOrDefaultAsync();
         
            if (validacion == null)
                return false;
            return true;


        }

        public async Task<bool> Delete(int id)
        {
            var iduser = await _dbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(iduser == null)
                return false;

            _dbContext.User.Remove(iduser);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
