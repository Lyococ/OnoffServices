using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onoff.Model;
using Onoff.Model.Validation;
using System.Threading.Tasks;

namespace Onoff.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private static readonly List<TaskItem> Tasks = new()
        {
            new TaskItem { Id = 1, Description = "Preparar informe", Completed = false },
            new TaskItem { Id = 2, Description = "Comprar ropa", Completed = true },
            new TaskItem { Id = 3, Description = "Lavar dientes", Completed = false }
        };

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetTasks()
        {
            return Ok(Tasks);
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            Tasks.Remove(task);
            return NoContent();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddTask([FromBody] TaskItem newTask)
        {
            var validator = new TaskItemValidator();
            var result = validator.Validate(newTask);

            if (!result.IsValid)
                return BadRequest(result.Errors);


            newTask.Id = Tasks.Count > 0 ? Tasks.Max(t => t.Id) + 1 : 1;
            Tasks.Add(newTask);
            return CreatedAtAction(nameof(GetTasks), new { id = newTask.Id }, newTask);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("count")]
        public IActionResult GetTaskCount()
        {
            var total = Tasks.Count;
            var completed = Tasks.Count(t => t.Completed);
            var pending = Tasks.Count(t => !t.Completed);

            return Ok(new { total, completed, pending });
        }
    }
}
