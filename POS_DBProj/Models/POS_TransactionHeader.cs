using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace POS_DBProj.Models
{
    public class POS_TransactionHeader
    {
        [Key]
        public long TransactionID { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "decimal")]
        public decimal PriceBeforeTax { get; set; }
        [Column(TypeName = "decimal")]
        public decimal AmountTendered { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }
        [Column(TypeName = "decimal")]
        public decimal VatAmount { get; set; }
        [Column(TypeName = "decimal")]
        public decimal TotalAmount { get; set;}
        public POS_Users POSUsers { get; set; }
        public long UserID { get; set; } // Foreign Key
        [Column(TypeName = "bit")] 
        public bool IsVoided { get; set; }
        public int TicketNumber { get; set; }

    }
}
