using Microsoft.AspNetCore.Mvc;
using Todo_API.Dto;
using Todo_API.IRepository;
using Todo_API.Model;

namespace Todo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Todo>))]
        public IActionResult GetTodos()
        {
            var todos = _todoRepository.GetTodos();
            return Ok(todos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(Todo))]
        public IActionResult GetTodoById(int id)
        {
            if (!_todoRepository.TodoExists(id))
            {
                return NotFound();
            }

            var todo = _todoRepository.GetTodoById(id);
            return Ok(todo);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Todo> CreateTodo([FromBody] TodoDto createTodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTodo = _todoRepository.CreateTodo(createTodo);
            if (createdTodo == null)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return Ok(createdTodo);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(200)]
        public ActionResult<Todo> EditTodo(int id, [FromBody] TodoDto editTodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var editedTodo = _todoRepository.EditTodo(id, editTodo);
            if (editedTodo == null)
            {
                return StatusCode(404, "Task does not exist.");
            }
            return Ok(editedTodo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public IActionResult DeleteTodo(int id)
        {
            var deleted = _todoRepository.DeleteTodo(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
