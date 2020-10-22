using System.Linq;
using SafeCity.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SafeCity.Controllers
{
    [Route("api/v1/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger<ProjectsController> _logger;
        public ProjectsController(ILogger<ProjectsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ProjectDataStore.Current.Projects);
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var result = ProjectDataStore.Current.Projects.Find(x => x.Id == id);

            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProjectCreateDto project)
        {
            var maxId = ProjectDataStore.Current.Projects.Max(x => x.Id);
            var newProject = new ProjectDto()
            {
                Id = ++maxId,
                Name = project.Name
            };

            return CreatedAtRoute("GetById", new { newProject.Id }, newProject);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] ProjectCreateDto project)
        {
            var result = ProjectDataStore.Current.Projects.Find(x => x.Id == id);

            if (result == null)
            {
                _logger.LogInformation($"Put project. Project with id={id} was not found");
                return NotFound();
            }

            //Update in database here

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<ProjectCreateDto> doc)
        {
            var result = ProjectDataStore.Current.Projects.Find(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            var projectToPatch = new ProjectCreateDto()
            {
                Name = result.Name,
                AddressName = result.AddressName,
                ShortDescription = result.ShortDescription,
                LongDescription = result.LongDescription,
                Logo = result.Logo,
                Lat = result.Lat,
                Lon = result.Lon,
                Images = result.Images,
                RequiredAmount = result.RequiredAmount,
            };

            doc.ApplyTo(projectToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(projectToPatch))
            {
                return BadRequest(ModelState);
            }

            //Update in database here

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = ProjectDataStore.Current.Projects.Find(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            //Delete from database here

            return NoContent();
        }
    }
}
