namespace SafeCity.DTOs
{
    public class ProjectDto: ProjectBaseDto
    {
        public string LongDescription { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string[] Images { get; set; }
    }
}
