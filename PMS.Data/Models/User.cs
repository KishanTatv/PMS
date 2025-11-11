using System.ComponentModel.DataAnnotations;

namespace PMS.Data.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNo { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

    }
}
