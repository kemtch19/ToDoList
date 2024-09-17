using Microsoft.AspNetCore.Mvc;
using ToDoList.Services.Interface;

namespace ToDoList.App.Controllers.Tareas
{
    public class TareaController: Controller
    {
        private readonly ITareaRepository _tareaRepository;
        public string ErrorMessage = "Server Error: The request has not been resolve";
        public string SuccesfulyMessage = "The task has been created successfully";
        public TareaController(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        //Get all coders
        [HttpGet]
        [Route("Tarea/List")]
        public async Task<IActionResult> GetTarea()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(Utils.Exceptions.StatusError.CreateBadRequest());
            }

            try
            {
                var tareas = await _tareaRepository.GetTarea();
                return Ok(tareas);
            }
            catch (Exception e)
            {
                return BadRequest($"error: {e.Message}");
            }
        }
    }
}