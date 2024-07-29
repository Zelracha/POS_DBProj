using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace POS_DBProj.Models
{
    public class POS_Leads
    {
        [Key]
        public long LeadID { get; set; }
        public long UserID { get; set; }
        [StringLength(50)]
        [Required]
        public string Passcode { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? UpdatedDate { get; set; }
    }
}
