using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("Peripheral")]
    public class EPeripheral : EBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PeripheralId { get; set; }
        
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [StringLength(6)]
        public string PeripheralColor { get; set; }

        [Required]
        [StringLength(50)]
        public string PeripheralName { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string AssetTag{ get; set; }




        public virtual EEmployee Employee { get; set; }
    }
}
