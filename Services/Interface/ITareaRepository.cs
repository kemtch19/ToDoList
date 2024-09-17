using ToDoList.Models;

namespace ToDoList.Services.Interface
{
    public interface ITareaRepository
    {
        void AddTarea(Tarea tarea);
        Task<IEnumerable<Tarea>> GetTarea();
    }
}