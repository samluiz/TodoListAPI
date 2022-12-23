using TaskApi.Models;

namespace TaskApi.Repositories.Interfaces
{
    public interface ITaskRepository
    {

        Task<List<Todo>> FindAllTasks();
        Task<Todo> FindTaskById(int id);
        Task<Todo> AddTask(Todo todo);
        Task<Todo> UpdateTask(Todo todo, int id);
        Task<bool> DeleteTask(int id);
    }
}
