using Todo_API.Dto;
using Todo_API.Model;

namespace Todo_API.IRepository
{
    public interface ITodoRepository
    {
        ICollection<Todo> GetTodos();
        Todo GetTodoById(int id);
        Todo CreateTodo(TodoDto createTodo);
        Todo EditTodo(int id, TodoDto editTodo);
        bool DeleteTodo(int id);
        bool TodoExists(int id);
        bool Save();
    }
}
