using MongoDB.Driver;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IConfiguration configuration){
            var client = new MongoClient (configuration.GetConnectionString("DbConnection"));
            _database = client.GetDatabase(configuration["MongoDbSettings:Database"]);
        }

        public IMongoCollection<Tarea> Tareas => _database.GetCollection<Tarea>("Tasks");
    }
}