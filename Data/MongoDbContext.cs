using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ToDoList.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IConfiguration configuration){
            var client = new MongoClient (configuration.GetConnectionString("DbConnection"));
            _database = client.GetDatabase(configuration["MongoDbSettings:Database"]);
        }

        public IMongoCollection<Task> Tasks => _database.GetCollection<Task>("Tasks");
    }
}