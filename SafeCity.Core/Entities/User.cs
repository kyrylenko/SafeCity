using System;
using System.ComponentModel.DataAnnotations;

namespace SafeCity.Core.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Picture { get; set; }
        public Role Role { get; set; }
    }
}
