using Todo_API.Dto;
using Todo_API.Model;

namespace Todo_API.IRepository
{
    public interface ITodoRepository
    {
        Task<ICollection<Todo>> GetTodosAsync();
        Task<Todo> GetTodoByIdAsync(int id);
        Task<Todo> CreateTodoAsync(TodoDto createTodo);
        Task<Todo> EditTodoAsync(int id, TodoDto editTodo);
        Task<bool> DeleteTodoAsync(int id);
        Task<bool> TodoExistsAsync(int id);
        Task<bool> SaveAsync();
    }
}