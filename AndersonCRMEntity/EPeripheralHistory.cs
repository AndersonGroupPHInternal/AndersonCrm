using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("PeripheralHistory")]
    public class EPeripheralHistory : EBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PeripheralHistoryId { get; set; }

        [ForeignKey("Peripheral")]
        public int PeripheralId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(6)]
        public string PeripheralHistoryColor { get; set; }

        public virtual EEmployee Employee { get; set; }
        public virtual EPeripheral Peripheral { get; set; }
    }
}