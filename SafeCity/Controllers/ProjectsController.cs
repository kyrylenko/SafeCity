using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SafeCity.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SafeCity.Core.Entities;
using SafeCity.Core.Repositories;

namespace SafeCity.Controllers
{
    [Route("api/v1/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectsController(ILogger<ProjectsController> logger, 
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _projectRepository = projectRepository ?? throw new ArgumentException(nameof(projectRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectRepository.GetAllAsync();

            var dto = _mapper.Map<IEnumerable<ProjectBaseDto>>(projects);

            return Ok(dto);
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id, true);

            if (project == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ProjectDto>(project);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectCreateDto project)
        {
            var entity = _mapper.Map<Project>(project);
            
            _projectRepository.CreateProjectAsync(entity);
            await _projectRepository.SaveAsync();

            var dto = _mapper.Map<ProjectDto>(entity);

            return CreatedAtRoute("GetById", new { dto.Id }, dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProjectCreateDto project)
        {
            var actualProject = await _projectRepository.GetByIdAsync(id, false);

            if (actualProject == null)
            {
                _logger.LogInformation($"Put project. Project with id={id} was not found");
                return NotFound();
            }

            _mapper.Map(project, actualProject);
            //_projectRepository.UpdateProjectAsync(id, entity);
            await _projectRepository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ProjectCreateDto> patchDoc)
        {
            var actualProject = await _projectRepository.GetByIdAsync(id, false);

            if (actualProject == null)
            {
                return NotFound();
            }

            var projectDtoToPatch = _mapper.Map<ProjectCreateDto>(actualProject);

            patchDoc.ApplyTo(projectDtoToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(projectDtoToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(projectDtoToPatch, actualProject);
            //_projectRepository.UpdateProjectAsync(id, entity);
            await _projectRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var actualProject = await _projectRepository.GetByIdAsync(id, false);

            if (actualProject == null)
            {
                return NotFound();
            }

            actualProject.IsDeleted = true;
            await _projectRepository.SaveAsync();

            return NoContent();
        }
    }
}
