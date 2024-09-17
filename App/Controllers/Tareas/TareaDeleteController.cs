using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Services.Interface;

namespace ToDoList.App.Controllers.Tareas
{
    public class TareaDeleteController : Controller
    {
        private readonly ITareaRepository _tareaRepository;
        public TareaDeleteController(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        [HttpPut]
        [Route("tarea/{id}/delete")]
        public async Task<IActionResult> DeleteTask(string id)
        {
            try
            {
                _tareaRepository.DeleteTareaAsync(id);
                return Ok(new { message = "the task has been deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server Error: the request has not been resolved", detail = ex.Message });
            }
        }
    }
}