using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POS_DBProj.Models
{
    public class POS_ModuleRoles
    {
        [Key]
        public long ModuleRoleID { get; set; }
        public long RoleID { get; set; }
        public long ModuleID { get; set; }
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
