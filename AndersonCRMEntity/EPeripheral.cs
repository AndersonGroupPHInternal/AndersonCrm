using BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("Peripheral")]
    public class EPeripheral : EBase
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeripheralId { get; set; }
        [ForeignKey("PeripheralType")]
        public int PeripheralTypeId { get; set; }


        [StringLength(50)]
        public string AssetTag { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string SerialNumber { get; set; }

        public virtual EEmployee Employee { get; set; }
        public virtual EPeripheralType PeripheralType { get; set; }

        public virtual ICollection<EPeripheralHistory> PeripheralHistories { get; set; }
    }
}
