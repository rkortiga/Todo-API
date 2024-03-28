using Microsoft.AspNetCore.Mvc;
using Todo_API.Dto;
using Todo_API.IRepository;

namespace Todo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoService;

        public TodoController(ITodoRepository todoService)
        {
            _todoService = todoService ?? throw new ArgumentNullException(nameof(todoService));
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            var todos = _todoService.GetTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult GetTodoById(int id)
        {
            var todo = _todoService.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public IActionResult CreateTodo([FromBody] TodoDto createTodo)
        {
            if (createTodo == null)
            {
                return BadRequest("Invalid request body.");
            }

            var createdTodo = _todoService.CreateTodo(createTodo);
            if (createdTodo == null)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Created("api/Todo", createTodo);
        }



        [HttpPut("{id}")]
        public IActionResult EditTodo(int id, [FromBody] TodoDto updateTodo)
        {
            if (updateTodo == null)
            {
                return BadRequest("Invalid request body.");
            }

            var updatedTodo = _todoService.EditTodo(id, updateTodo);
            if (updatedTodo == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodoById(int id)
        {
            var deleted = _todoService.DeleteTodo(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
