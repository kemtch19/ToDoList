using Microsoft.AspNetCore.Mvc;
using ToDoList.Services.Interface;

namespace ToDoList.App.Controllers.Tareas
{
    [ApiController]
    [Route("api/updateTask")]
    public class TareaUpdateController : ControllerBase
    {
        private readonly ITareaRepository _tareaRepository;
        public TareaUpdateController(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        [HttpPut("{id}/statusById")]
        public async Task<IActionResult> UpdateStatus(string id, [FromBody] string newStatus)
        {
            if (string.IsNullOrEmpty(newStatus))
            {
                return BadRequest("the status parameter not have empty value");
            }

            try
            {
                await _tareaRepository.Update(id, newStatus);
                return Ok("Task status updated successfully");
            }
            catch (Exception e)
            {
                throw new Exception("bad request, try again", e);
            }
        }

        [HttpPut("{name}/statusByName")]
        public async Task<IActionResult> UpdateStatusByName(string name, [FromBody] string statusUpdate)
        {
            if (string.IsNullOrEmpty(statusUpdate))
            {
                return BadRequest("the name parameter not have empty value");
            }

            try
            {
                await _tareaRepository.UpdateNameAsync(name, statusUpdate);
                return Ok("Task status updated successfully");
            }
            catch (Exception e)
            {
                throw new Exception("bad request, try again", e);
            }
        }
    }
}