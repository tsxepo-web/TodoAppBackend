using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Todo.Application.Models;
public class Todos
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool Completed { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
