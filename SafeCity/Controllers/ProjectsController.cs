﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SafeCity.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ProjectDto>(project);

            return Ok(dto);
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
