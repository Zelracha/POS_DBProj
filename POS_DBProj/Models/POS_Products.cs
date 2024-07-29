using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POS_DBProj.Models
{
    public class POS_Products
    {
        [Key]
        public long ProductID { get; set; }
        [StringLength(50)]
        [Required]
        public string ProductName { get; set; }
        public long CategoryID { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName = "bit")]
        public bool IsDeleted { get; set; }
    }
}
