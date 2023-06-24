using Todo.Application.Models;

namespace Todo.Application.Interfaces;
public interface ITodoService
{
    Task<IEnumerable<Todos>> GetTodosAsync();
    Task<Todos> GetTodoAsync(string id);
    Task CreateTodoAsync(Todos todo);
    Task UpdateTodoAsync(Todos todo);
    Task DeleteTodoAsync(string id);
}