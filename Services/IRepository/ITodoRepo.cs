using server_to_do.Dto.Request;
using server_to_do.Models;
using SimpleAppCRUD.DTO.Respon;

namespace server_to_do.Services.IRepository
{
    public interface ITodoRepo<T>
    {
        public Task<ResponAllData<Todo>> GetAllTodosAsync(string title, int page, int size);
        public Task<T> AddTodosAsync(RequestTodosDto item);
        public Task<T> UpdateTodosAsync(int id, RequestTodosDto item);
        public Task<T> DeleteTodosAsync(int id);
        public Task<T> TodosCompleted(int id);
        public Task<IEnumerable<Todo>> GetUpcomingReminders(DateTime currentTime);

    }
}
