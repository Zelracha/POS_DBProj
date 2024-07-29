using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POS_DBProj.Models
{
    public class POS_Modules
    {
        [Key]
        public long ModuleID { get; set; }
        [StringLength(50)]
        [Required]
        public string ModuleName { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? UpdatedDate { get; set; }
        [StringLength(50)]
        public string Controller { get; set; }
        [Column(TypeName = "bit")]
        public bool IsDeleted { get; set; }
    }
}
