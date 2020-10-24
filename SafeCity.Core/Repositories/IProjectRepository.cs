using System.Collections.Generic;
using System.Threading.Tasks;
using SafeCity.Core.Entities;

namespace SafeCity.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id, bool includeDonations);
        void CreateProjectAsync(Project project);
        void UpdateProjectAsync(int id, Project project);
        Task<bool> SaveAsync();
    }
}
