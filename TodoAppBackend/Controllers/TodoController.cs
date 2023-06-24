using Microsoft.AspNetCore.Mvc;
using Todo.Application.Interfaces;
using Todo.Application.Models;

namespace TodoAppBackend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }
    [HttpGet]
    public async Task<IEnumerable<Todos>> GetTodos()
    {
        return await _todoService.GetTodosAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Todos>> GetTodo(string id)
    {
        return await _todoService.GetTodoAsync(id);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodo(string id, [FromBody] Todos todo)
    {
        if (id != todo.Id)
        {
            return BadRequest();
        }
        await _todoService.UpdateTodoAsync(todo);
        return NoContent();
    }
    [HttpPost]
    public async Task<IActionResult> PostTodo(Todos todo)
    {
        await _todoService.CreateTodoAsync(todo);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTodo(string id)
    {
        var todoToDelete = await _todoService.GetTodoAsync(id);
        if (todoToDelete == null)
        {
            return NotFound();
        }
        await _todoService.DeleteTodoAsync(todoToDelete.Id);
        return NoContent();
    }
}