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
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async void CreateProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result >= 0;
        }
    }
}
