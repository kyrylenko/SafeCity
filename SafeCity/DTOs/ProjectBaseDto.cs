using SafeCity.Core.Entities;

namespace SafeCity.DTOs
{
    public class ProjectBaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string AddressName { get; set; }
        public string Logo { get; set; }
        public ProjectState State { get; set; } = ProjectState.Suggested;
        public decimal RequiredAmount { get; set; }
    }
}
