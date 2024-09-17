using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDoList.Models
{
    public class Tarea
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? name { get; set; }
        public string? status { get; set; } // pending, in_process, completed
        public Boolean? isDeleted { get; set; } // isDeleted = false the task is actived when deleted from database use isDeleted = true
        public List<Subtask>? subtasks { get; set; }
    }
}