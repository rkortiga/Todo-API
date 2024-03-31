﻿using Todo_API.Context;
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

        public ICollection<Todo> GetTodos()
        {
            return _context.Todos.OrderBy(p => p.Id).ToList();
        }

        public Todo GetTodoById(int id)
        {
            return _context.Todos.Where(p => p.Id == id).FirstOrDefault();
        }

        public Todo CreateTodo(TodoDto createTodo)
        {
            var todo = new Todo
            {
                Task = createTodo.Task,
                CreateDate = DateOnly.FromDateTime(DateTime.Now),
                IsCompleted = createTodo.IsCompleted
            };
            _context.Todos.Add(todo);
            if (Save())
            {
                return todo;
            }
            return null;
        }

        public Todo EditTodo(int id, TodoDto editTodo)
        {
            var todo = GetTodoById(id);
            if (todo == null)
            {
                return null;
            }
            todo.Task = editTodo.Task;
            todo.IsCompleted = editTodo.IsCompleted;
            Save();
            return todo;
        }

        public bool DeleteTodo(int id)
        {
            var todo = GetTodoById(id);
            if (todo == null)
            {
                return false;
            }
            _context.Todos.Remove(todo);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TodoExists(int id)
        {
            return _context.Todos.Any(p => p.Id == id);
        }
    }
}
