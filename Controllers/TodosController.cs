using Microsoft.AspNetCore.Mvc;
using server_to_do.Dto.Request;
using server_to_do.Models;
using server_to_do.Services;
using SimpleAppCRUD.DTO.Respon;

namespace server_to_do.Controllers
{
    [Route("/v1/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodosService service;
        public TodosController(TodosService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ResponHeader> addTodos([FromBody] RequestTodosDto request)
        {
            return await service.AddTodosAsync(request);
        }

        [HttpGet]
        public async Task<ResponAllData<Todo>> getAllTodo(string? title, int page = 1, int size = 10)
        {
            return await service.GetAllTodosAsync(title, page, size);
        }

        [HttpDelete("id")]
        public async Task<ResponHeader> deleteTodos(int id)
        {
            return await service.DeleteTodosAsync(id);
        }

        [HttpPatch("completed")]
        public async Task<ResponHeader> todosCompleted(int id)
        {
            return await service.TodosCompleted(id);
        }

        [HttpPatch("id")]
        public async Task<ResponHeader> updateTodos(int id, [FromBody] RequestTodosDto request)
        {
            return await service.UpdateTodosAsync(id, request); 
        }

        [HttpGet("reminders")]
        public async Task<IActionResult> GetUpcomingReminders()
        {
            var currentTime = DateTime.Now;
            var reminders = await service.GetUpcomingReminders(currentTime);
            return Ok(reminders);
        }

    }
}
