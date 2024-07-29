using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace POS_DBProj.Models
{
    public class POS_TransactionDetails
    {
        [Key]
        public long pID { get; set; }
        public POS_TransactionHeader POSTransactionHeader { get; set; }
        public long TransactionID { get; set; }
        public int ItemQuantity { get; set; }
        public POS_Products POSProducts { get; set; }
        public long ProductID { get; set; }
        [Column(TypeName = "bit")]
        public bool IsDiscounted { get; set; }
        [Column(TypeName = "decimal")]
        public decimal ProductPrice { get; set; }
    }
}
