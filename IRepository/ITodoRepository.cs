using Todo_API.Dto;
using Todo_API.Model;

namespace Todo_API.IRepository
{
    public interface ITodoRepository
    {
        ICollection<Todo> GetTodos();
        Todo GetTodoById(int id);
        bool CreateTodo(TodoDto createTodo);
        bool EditTodo(int id, TodoDto updateTodo);
        bool DeleteTodo(int id);
        bool Save();
    }
}
