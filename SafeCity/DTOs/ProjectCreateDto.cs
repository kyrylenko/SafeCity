using System.ComponentModel.DataAnnotations;

namespace SafeCity.DTOs
{
    public class ProjectCreateDto
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string ShortDescription { get; set; }
        [MaxLength(8192)]
        public string LongDescription { get; set; }
        //TODO: consider setting Ukrainian coordinates range: lat: 44.41886 to 52.18903 lon: 22.20555 to 40.13222
        [Range(typeof(double), "-90", "90")]
        public double Lat { get; set; }
        [Range(typeof(double), "-180", "180")]
        public double Lon { get; set; }
        [MaxLength(1024)]
        public string AddressName { get; set; }
        [MaxLength(256)]
        public string Logo { get; set; }
        public string[] Images { get; set; }
        public string[] Attachments { get; set; }
        [Range(typeof(decimal), "0", "10000000")]
        public decimal RequiredAmount { get; set; }
    }
}
