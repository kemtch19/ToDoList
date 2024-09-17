using ToDoList.Models;

namespace ToDoList.Services.Interface
{
    public interface ITareaRepository
    {
        void AddTarea(Tarea tarea);
        Task<IEnumerable<Tarea>> GetTarea();
        Task<Tarea> GetTareaID(string id);
        Task Update(string tareaId, string newStatus);
        Task<Tarea> UpdateNameAsync(string NameUpdate, string statusUpdate);
        Task DeleteTareaAsync(string id);
    }
}