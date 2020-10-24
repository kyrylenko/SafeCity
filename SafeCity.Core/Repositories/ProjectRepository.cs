using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SafeCity.Core.Entities;

namespace SafeCity.Core.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly SafeCityContext _context;

        public ProjectRepository(SafeCityContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.Where(x => !x.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id, bool includeDonations)
        {
            if (includeDonations)
            {
                return await _context.Projects
                    .Include(x => x.Donations)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            }

            return await _context.Projects
                //.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async void CreateProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public void UpdateProjectAsync(int id, Project project)
        {
            //It is empty by design. 
            //It's enough to call in the controller:

            //actualProject = _projectRepository.GetByIdAsync(id, false);
            //_mapper.Map(project, actualProject);
            //await _projectRepository.SaveAsync();

            //BUT it is required to NOT use .AsNoTracking() in the GetByIdAsync() to make sure actualProject is tracked by EF
            //So, this method still should be present, because if use some different implementation of IProjectRepository (without EF), it will not work
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result >= 0;
        }
    }
}
