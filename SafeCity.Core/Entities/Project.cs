using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeCity.Core.Entities
{
    public class Project: AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string ShortDescription { get; set; }
        [MaxLength(8192)]
        public string LongDescription { get; set; }
        [MaxLength(1024)]
        public string AddressName { get; set; }
        [MaxLength(256)]
        public string Logo { get; set; }
        public ProjectState State { get; set; } = ProjectState.Suggested;
        [Column(TypeName = "decimal(18, 2)")]
        [Range(typeof(decimal), "0", "10000000")]
        public decimal RequiredAmount { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string[] Images { get; set; } = { };
        public string[] Attachments { get; set; } = { };
        public bool IsDeleted { get; set; }
        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
    }
}
