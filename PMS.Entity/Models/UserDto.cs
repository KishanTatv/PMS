using System.ComponentModel.DataAnnotations;

namespace PMS.Entity.Models
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
