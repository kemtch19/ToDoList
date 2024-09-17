namespace ToDoList.Models
{
    public class Subtask
    {
        public string? name { get; set; }
        public string? status { get; set; }
        public Boolean? isDeleted { get; set; } // isDeleted = false the task is actived when deleted from database use isDeleted = true
    }
}