using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services.Interface;

namespace ToDoList.App.Controllers.Tareas
{
    public class TareaCreateController : Controller
    {
        private readonly ITareaRepository _tareaRepository;
        public string ErrorMessage = "Server Error: The request has not been resolve";
        public string SuccesfulyMessage = "The task has been created successfully";
        public TareaCreateController(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        [HttpPost]
        [Route("Task/Create")]
        public IActionResult PostTarea([FromBody] Tarea tarea)
        {
            if (!ModelState.IsValid)
            { /* validate for the bad data for the request */
                return BadRequest(Utils.Exceptions.StatusError.CreateBadRequest());
            }
            try
            {
                _tareaRepository.AddTarea(tarea);
                return Ok(SuccesfulyMessage);
            }
            catch (Exception)
            {
                throw new Exception(ErrorMessage);
            }
        }
    }
}