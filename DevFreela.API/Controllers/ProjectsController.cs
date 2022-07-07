using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            // Services
            //var projects = _projectService.GetAll(query);

            // CQRS Query
            var getAllProjectsQuery = new GetAllProjectsQuery(query);
            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        // api/projects/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var project = _projectService.GetById(id); // Services

            // Query CQRS
            var getProjectByIdQuery = new GetProjectByIdQuery(id);
            var project = await _mediator.Send(getProjectByIdQuery);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            

            //var projectId = _projectService.Create(inputModel); // applications service

            // CQRS Command
            var projectId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = projectId }, command);
        }

        // api/projects/2
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
            {
                return BadRequest();
            }

            // Services
            //_projectService.Update(inputModel);

            // CQRS Command
            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //_projectService.Delete(id);

            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/comments
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            //_projectService.CreateComment(inputModel);

            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/4/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        // api/projects/4/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }
    }
}
