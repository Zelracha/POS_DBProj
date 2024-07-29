using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace POS_DBProj.Models
{
    public class POS_Roles
    {
        [Key]
        public long RoleID { get; set; }
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName = "bit")]
        public bool IsDeleted { get; set; }
    }
}
