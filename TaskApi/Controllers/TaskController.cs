using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.Repositories.Interfaces;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> FindAllTasks()
        {
            List<Todo> tasks = await _taskRepository.FindAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> FindTaskById(int id)
        {
            Todo task = await _taskRepository.FindTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> addTask(Todo task)
        {
            Todo newTask = await _taskRepository.AddTask(task);
            return Ok(newTask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> updateTodo(Todo task, int id)
        {
            Todo updatedTask = await _taskRepository.UpdateTask(task, id);
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> deleteTask(int id)
        {
            bool isDeleted = await _taskRepository.DeleteTask(id);
            return Ok(isDeleted);
        }
    }
}
