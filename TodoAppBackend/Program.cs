using MongoDB.Driver;
using Todo.Application;
using Todo.Application.Interfaces;
using Todo.Application.Models;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = "mongodb://mytodo-app:iMQPu1NlKYhXBq3LCo2URv82w0zjbnNIV42ws7fGJTxSjF59Y34eymyaG9QoVt4bTxGEhez7CibWACDbur6U3Q%3D%3D@mytodo-app.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@mytodo-app@";
var mongoDatabaseName = "Todos";
var mongoCollectionName = "todo";

var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
var mongoCollection = mongoDatabase.GetCollection<Todos>(mongoCollectionName);
builder.Services.AddSingleton(mongoCollection);

builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
