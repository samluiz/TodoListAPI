using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Models;
using TaskApi.Repositories.Interfaces;

namespace TaskApi.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly TaskDBContext _dbContext;

        public UserRepository(TaskDBContext taskDBContext)
        {
            _dbContext = taskDBContext;
        }
        public async Task<List<User>> FindAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> FindUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<User> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUser(User user, int id)
        {
            User userById = await FindUserById(id);

            if (userById == null)
            {
                throw new Exception($"User with ID: {id} was not found");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

             _dbContext.Users.Update(userById);
             await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> DeleteUser(int id)
        {
            User userById = await FindUserById(id);

            if (userById == null)
            {
                throw new Exception($"User with ID {id} was not found");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }


    }
}
