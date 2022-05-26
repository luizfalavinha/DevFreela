using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        public ProjectsController(IOptions<OpeningTimeOption> option)
        {
            _option = option.Value;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok(_option);
        }

        // api/projects/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            if (createProject.Title?.Length > 50)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetById", new { id = createProject.Id }, createProject);
        }

        // api/projects/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
        {
            if (updateProject.Description?.Length > 200)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // api/projects/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Buscar, se não existir, retorna NotFound()

            // Remover

            return NoContent();
        }

        // api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }

        // api/projects/4/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            // iniciar projeto

            return NoContent();
        }

        // api/projects/4/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            // finalizar projeto

            return NoContent();
        }
    }
}
