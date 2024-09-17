using MongoDB.Driver;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Services.Interface;

namespace ToDoList.Services.Repository
{
    public class TareaRepository: ITareaRepository
    {
        private readonly IMongoCollection<Tarea> _mongoCollection;
        private string Error = "The Task not found";
        // add the constructor with the mongo collection
        public TareaRepository(MongoDbContext context){
            _mongoCollection = context.Tareas;
        }

        public void AddTarea(Tarea tarea){
            _mongoCollection.InsertOne(tarea);
        }
        // get all tasks
        public async Task<IEnumerable<Tarea>> GetTarea()
        {
            //we get all tasks
            var tarea = await _mongoCollection.Find(_ => true).ToListAsync();
            return tarea;
        }
    }
}