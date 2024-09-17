using MongoDB.Driver;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Services.Interface;

namespace ToDoList.Services.Repository
{
    public class TareaRepository : ITareaRepository
    {
        private readonly IMongoCollection<Tarea> _mongoCollection;
        private string Error = "The Task not found";
        // add the constructor with the mongo collection
        public TareaRepository(MongoDbContext context)
        {
            _mongoCollection = context.Tareas;
        }

        // get all tasks
        public void AddTarea(Tarea tarea)
        {
            _mongoCollection.InsertOne(tarea);
        }

        // create task and subtask
        public async Task<IEnumerable<Tarea>> GetTarea()
        {
            //we get all tasks
            var tarea = await _mongoCollection.Find(_ => true).ToListAsync();
            return tarea;
        }

        public async Task<Tarea> GetTareaID(string id)
        {
            try
            {
                return await _mongoCollection.Find(Tarea => Tarea.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al obtener el coder", ex);
            }
        }

        public async Task Update(string tareaId, string newStatus)
        {
            /* create a new filter for find the task by id  */
            var filter = Builders<Tarea>.Filter.Eq(t => t.Id, tareaId);

            /* create the update, changing the item status for newStatus */
            var update = Builders<Tarea>.Update.Set(t => t.status, newStatus);

            /* execute the update for only one document find*/
            await _mongoCollection.UpdateOneAsync(filter, update);
        }


        public async Task<Tarea> UpdateNameAsync(string NameUpdate, string statusUpdate)
        {
            // Filter for the main task
            var filterTask = Builders<Tarea>.Filter.Eq(t => t.name, NameUpdate);

            // Filter for the array of subtasks
            var filterSubtask = Builders<Tarea>.Filter.Eq("subtasks.name", NameUpdate);

            // Combine filters using OR: checks if the name exists in the main task or in any subtask
            var combinedFilter = Builders<Tarea>.Filter.Or(filterTask, filterSubtask);

            // Check if any document matches one of the filters
            var tarea = await _mongoCollection.Find(combinedFilter).FirstOrDefaultAsync();

            if (tarea != null)
            {
                // If a task or subtask with the name is found, proceed with the update

                // If the name matches the main task
                if (tarea.name == NameUpdate)
                {
                    var update = Builders<Tarea>.Update.Set(t => t.status, statusUpdate);
                    return await _mongoCollection.FindOneAndUpdateAsync(filterTask, update);
                }

                // If the name matches a subtask
                else
                {
                    var updateSubtask = Builders<Tarea>.Update.Set("subtasks.$.status", statusUpdate);
                    return await _mongoCollection.FindOneAndUpdateAsync(filterSubtask, updateSubtask);
                }
            }
            else
            {
                // If no task or subtask with the given name is found, you can return null or throw an exception
                return null; // Or you can return a custom message
            }
        }

        // soft delete from a one list not everyone in the list item
        public async Task DeleteTareaAsync(string id)
        {
            var filter = Builders<Tarea>.Filter.Eq(t => t.Id, id);
            var updateParam = Builders<Tarea>.Update.Set(t => t.isDeleted, true);
            await _mongoCollection.UpdateOneAsync(filter, updateParam);
        }
    }
}