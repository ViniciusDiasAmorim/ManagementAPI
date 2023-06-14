using Gerenciador.Context;
using Gerenciador.Models;
using Gerenciador.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Gerenciador.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ManagementContext _context;
        public UserRepository(ManagementContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(user => user.Id == id);

            return user;
        }

        public async Task<User> GetByName(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Name.Contains(name));

            return user;
        }

        public async Task<User> Post(User user)
        {
            bool isValid = Validation(user);
            if (!isValid)
            {
                return null;
            }

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Put(int id, User user)
        {
            var userChange = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (userChange == null)
            {
                return null;
            }

            userChange.Name = user.Name;
            userChange.Email = user.Email;
            userChange.Password = user.Password;

            bool isValid = Validation(userChange);
            if (!isValid)
            {
                return null;
            }

            await _context.SaveChangesAsync();

            return userChange;
        }
        public async Task<User> Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            
            if(user == null)
            {
                return null;
            }

            _context.Users.Remove(user); 
            
            await _context.SaveChangesAsync();

            return user;
        }

        public bool Validation(User user)
        {

            var validationResults = new List<ValidationResult>();

            var validationContext = new ValidationContext(user);

            if (!Validator.TryValidateObject(user, validationContext, validationResults))
            {
                foreach (var validationResult in validationResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }

                return false;
            }

            return true;
        }
    }
}
