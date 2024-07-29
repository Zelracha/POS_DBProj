using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace POS_DBProj.Models
{
    public class POS_Users
    {
        [Key]
        public long UserID { get; set; }
        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string PasswordHash { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
