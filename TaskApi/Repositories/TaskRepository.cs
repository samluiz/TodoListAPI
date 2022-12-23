using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskApi.Data;
using TaskApi.Models;
using TaskApi.Repositories.Interfaces;

namespace TaskApi.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly TaskDBContext _dbContext;

        public TaskRepository(TaskDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Todo>> FindAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<Todo> FindTaskById(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Todo> AddTask(Todo todo)
        {
            await _dbContext.Tasks.AddAsync(todo);
            await _dbContext.SaveChangesAsync();
            return todo;
        }
        public async Task<Todo> UpdateTask(Todo todo, int id)
        {
            Todo taskById = await FindTaskById(id);

            if (taskById == null)
            {
                throw new Exception($"Task with ID: {id} was not found");
            }

            taskById.Name = todo.Name;
            taskById.Description = todo.Description;
            taskById.Status = todo.Status;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }

        public async Task<bool> DeleteTask(int id)
        {
            Todo taskById = await FindTaskById(id);

            if (taskById == null)
            {
                throw new Exception($"Task with ID: {id} was not found");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }


    }
}
