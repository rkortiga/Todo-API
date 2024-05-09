using Microsoft.EntityFrameworkCore;
using Todo_API.Context;
using Todo_API.Dto;
using Todo_API.IRepository;
using Todo_API.Model;

namespace Todo_API.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Todo>> GetTodosAsync()
        {
            return await _context.Todos.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<Todo> CreateTodoAsync(TodoDto createTodo)
        {
            var todo = new Todo
            {
                Task = createTodo.Task,
                CreateDate = DateOnly.FromDateTime(DateTime.Now),
                IsCompleted = createTodo.IsCompleted
            };
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> EditTodoAsync(int id, TodoDto editTodo)
        {
            var todo = await GetTodoByIdAsync(id);
            if (todo == null)
            {
                return null;
            }
            todo.Task = editTodo.Task;
            todo.IsCompleted = editTodo.IsCompleted;
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            var todo = await GetTodoByIdAsync(id);
            if (todo == null)
            {
                return false;
            }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return true;
        }
        
        public async Task<bool> TodoExistsAsync(int id)
        {
            return await _context.Todos.AnyAsync(p => p.Id == id);
        }
    }
}
