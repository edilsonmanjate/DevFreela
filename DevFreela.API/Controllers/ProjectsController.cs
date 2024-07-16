using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]

    public class ProjectsController : Controller
    {
        public readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetAll")]  
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);
            
            if (project == null) return NotFound();

            return Ok(project);
        }

        [HttpPost("Create")] 
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if (inputModel.Title.Length>50) return BadRequest();

            var id = _projectService.Create(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPost("Start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            return NoContent();
        }

        [HttpPost("Fininsh")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);
            return NoContent();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return NoContent();
        }

        [HttpPost("CreateComment")]
        public IActionResult CreateComment([FromBody] CreateCommentInputModel inputModel)
        {
            _projectService.CreateComment(inputModel);
            return NoContent();
        }

        [HttpPut("Update")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
        {
            if (inputModel.Description.Length > 200) return BadRequest();

            _projectService.Update(id, inputModel);
            return NoContent();
        }
        
    }
}
