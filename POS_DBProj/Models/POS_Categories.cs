using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace POS_DBProj.Models
{
    public class POS_Categories
    {
        [Key]
        public long CategoryID { get; set; }
        [StringLength(50)]
        [Required]
        public string CategoryName { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? UpdateDate { get; set; }
        [Column(TypeName = "bit")]
        public bool IsDeleted { get; set; }
    }
}
