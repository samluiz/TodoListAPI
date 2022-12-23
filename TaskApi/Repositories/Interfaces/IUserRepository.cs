using TaskApi.Models;

namespace TaskApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> FindAllUsers();
        Task<User> FindUserById(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user, int id);

        Task<bool> DeleteUser(int id);
    }
}
