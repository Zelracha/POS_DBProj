using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace POS_DBProj.Models
{
    public class POS_Pricing
    {
        [Key]
        public int Id { get; set; }
        public POS_Products POSProducts { get; set; }
        public long ProductID { get; set; }
        [StringLength(50)]
        [Required]
        public string ProductSize { get; set; }
        [Column(TypeName = "decimal")]
        public decimal ProductPrice { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName = "bit")]
        public bool IsDeleted { get; set; }
        public POS_Categories POSCategories { get; set; }
        public long CategoryID { get; set; }
    }
}
