using System.Linq;
using AutoMapper;
using SafeCity.Core.Entities;
using SafeCity.DTOs;
using SafeCity.Mappers.MappingActions;

namespace SafeCity.Mappers
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, ProjectBaseDto>();

            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.Raised,
                    opt => opt.MapFrom(src => src.Donations.Sum(d => d.Amount)));

            CreateMap<ProjectCreateDto, Project>()
                .AfterMap<SetAuditDataActionCreate<ProjectCreateDto, Project>>();
        }
    }
}
