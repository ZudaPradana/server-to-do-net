using Microsoft.EntityFrameworkCore;
using server_to_do.DB;
using server_to_do.Dto.Request;
using server_to_do.Models;
using server_to_do.Services.IRepository;
using SimpleAppCRUD.DTO.Respon;

namespace server_to_do.Services
{
    public class TodosService : ITodoRepo<ResponHeader>
    {
        private readonly AppDbContext _dbContext;
        public TodosService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<ResponHeader> AddTodosAsync(RequestTodosDto request)
        {
            Todo newTodo = new Todo
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                IsCompleted = request.IsCompleted,
                Reminder = request.Reminder,
            };
            _dbContext.Add(newTodo);
            await _dbContext.SaveChangesAsync();   
            
            return ResponHeaderMessage.GetDataCreated();
        }

        public async Task<ResponHeader> DeleteTodosAsync(int id)
        {
            Todo todoExist = await _dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todoExist != null) 
            {
                _dbContext.Todos.Remove(todoExist);
                await _dbContext.SaveChangesAsync();
                ResponHeader responHeader = ResponHeaderMessage.GetRequestSuccess();
                responHeader.message = $"Todo with ID {todoExist.Id} successfully deleted.";
                return responHeader;
            }
            return ResponHeaderMessage.GetDataNotFound();
        }

        public async Task<ResponAllData<Todo>> GetAllTodosAsync(string title, int page, int size)
        {
            // Use LinQ for query
            IQueryable<Todo> query = _dbContext.Todos;

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(x => x.Title == title);
            }

            List<Todo> todos = await query
                .Skip((page-1) * size)
                .Take(size)
                .ToListAsync();

            ResponHeader responHeader = ResponHeaderMessage.GetRequestSuccess();

            return new ResponAllData<Todo> { ResponHeader = responHeader, Data = todos}; 
        }

        public async Task<ResponHeader> TodosCompleted(int id)
        {
            Todo todoExist = await _dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todoExist != null)
            { 
                todoExist.IsCompleted = true;
                await _dbContext.SaveChangesAsync();
                ResponHeader responHeader = ResponHeaderMessage.GetRequestSuccess();
                responHeader.message = $"Task with ID {todoExist.Id} has successfully updated.";
                return responHeader;
            }
            return ResponHeaderMessage.GetDataNotFound();
        }

        public async Task<ResponHeader> UpdateTodosAsync(int id, RequestTodosDto request)
        {
            Todo todoExist = await _dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todoExist != null) 
            {
                if (request.Title != null)
                {
                    todoExist.Title = request.Title;
                }
                if (request.Description != null)
                {
                    todoExist.Description = request.Description;
                }
                if (request.IsCompleted != null)
                {
                    todoExist.IsCompleted = request.IsCompleted;
                }
                if (request.DueDate != null)
                {
                    todoExist.DueDate = request.DueDate;
                }
                if (request.Reminder != null)
                {
                    todoExist.Reminder = request.Reminder;
                }

                await _dbContext.SaveChangesAsync();
                ResponHeader responHeader = ResponHeaderMessage.GetRequestSuccess();
                responHeader.message = $"Task with ID {todoExist.Id} has successfully updated.";
                return responHeader;
            }
            return ResponHeaderMessage.GetDataNotFound();
        }

        public async Task<IEnumerable<Todo>> GetUpcomingReminders(DateTime currentTime)
        {
            // Mendapatkan pengingat yang akan datang dalam 5 menit ke depan
            var upcomingReminders = await _dbContext.Todos
                .Where(todo => todo.Reminder.HasValue
                               && todo.Reminder.Value > currentTime
                               && todo.Reminder.Value <= currentTime.AddMinutes(5))
                .ToListAsync();

            return upcomingReminders;
        }

    }
}
