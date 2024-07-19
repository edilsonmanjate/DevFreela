using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProjectCommand;
using DevFreela.Application.Commands.UpdateProjectCommand;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Application.Services.Interfaces;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        public readonly IProjectService _projectService;
        private readonly IMediator _mediator;
        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        [HttpGet("GetAll")]  
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery();
            var skills = await _mediator.Send(getAllProjectsQuery);

            return Ok(skills);
            //var projects = _projectService.GetAll(query);
            //return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);
            
            if (project == null) return NotFound();

            return Ok(project);
        }

        [HttpPost] 
        public IActionResult Post([FromBody] CreateProjectCommand command)
        {
            if (command.Title.Length>50) return BadRequest();

            //var id = _projectService.Create(inputModel);
            var id = _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPost("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            return NoContent();
        }

        [HttpPost("{id}/fininsh")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);
            await _mediator.Send(command);
            //_projectService.Delete(id);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> CreateComment(int id, [FromBody] CreateCommentCommand command)
        {
            //_projectService.CreateCommentCommand(inputModel);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200) return BadRequest();

            await _mediator.Send(command);
            return NoContent();

            //_projectService.Update(id, command);
            //return NoContent();
        }

    }
}
