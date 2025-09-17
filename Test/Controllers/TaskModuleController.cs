using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MODULES;
using SERVECES;

namespace Test.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskModuleController : ControllerBase
    {
        private readonly ITaskModuleService _taskModuleService;
        
        public TaskModuleController(ITaskModuleService taskModuleService)
        {
            _taskModuleService = taskModuleService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskModule taskModule)
        {
            if (taskModule != null)
            {
                var result = await _taskModuleService.Create(taskModule);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(500);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var taskModules = await _taskModuleService.ReadAll();
            if (taskModules != null && taskModules.ToList().Count > 0)
            {
                return Ok(taskModules);
            }
            return NoContent();
        }

        [HttpGet("{id:int:required}")]
        public async Task<IActionResult> ReadById(int id)
        {
            if (id > 0)
            {
                var taskModule = await _taskModuleService.ReadById(id);
                if (taskModule != null)
                {
                    return Ok(taskModule);
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(TaskModule taskModule)
        {
            if (taskModule != null && taskModule.Id > 0)
            {
                var result = await _taskModuleService.Update(taskModule);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(500);
            }
            return BadRequest();
        }

        [HttpDelete("{id:int:required}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var searchTaskModule = await _taskModuleService.ReadById(id);
                if (searchTaskModule != null)
                {
                    var result = await _taskModuleService.Delete(searchTaskModule);
                    if (result)
                    {
                        return Ok();
                    }
                    return StatusCode(500);
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}
