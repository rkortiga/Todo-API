using Microsoft.AspNetCore.Mvc;
using Todo_API.Dto;
using Todo_API.IRepository;
using Todo_API.Model;

namespace Todo_API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Todo>))]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _todoRepository.GetTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(Todo))]
        public async Task<IActionResult> GetTodoById(int id)
        {
            if (!await _todoRepository.TodoExistsAsync(id))
            {
                return NotFound();
            }

            var todo = await _todoRepository.GetTodoByIdAsync(id);
            return Ok(todo);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Todo>> CreateTodo([FromBody] TodoDto createTodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTodo = await _todoRepository.CreateTodoAsync(createTodo);
            if (createdTodo == null)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return Ok(createdTodo);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Todo>> EditTodo(int id, [FromBody] TodoDto editTodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var editedTodo = await _todoRepository.EditTodoAsync(id, editTodo);
            if (editedTodo == null)
            {
                return StatusCode(404, "Task does not exist.");
            }
            return Ok(editedTodo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var deleted = await _todoRepository.DeleteTodoAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
