using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PMS.Data.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Cover Type")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
