using MongoDB.Driver;
using Todo.Application.Interfaces;
using Todo.Application.Models;

namespace Todo.Application;
public class TodoService : ITodoService
{
    private readonly IMongoCollection<Todos> _todoCollection;
    public TodoService(IMongoCollection<Todos> todoCollection)
    {
        _todoCollection = todoCollection;
    }
    public async Task CreateTodoAsync(Todos todo)
    {
        await _todoCollection.InsertOneAsync(todo);
    }
    public async Task DeleteTodoAsync(string id)
    {
        await _todoCollection.DeleteOneAsync(x => x.Id == id);
    }
    public async Task<Todos> GetTodoAsync(string id)
    {
        return await _todoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<Todos>> GetTodosAsync()
    {
        return await _todoCollection.Find(_ => true).ToListAsync();
    }
    public async Task UpdateTodoAsync(Todos todo)
    {
        await _todoCollection.ReplaceOneAsync(x => x.Id == todo.Id, todo);
    }
}