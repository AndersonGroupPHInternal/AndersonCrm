using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("Employee")]
    public class EEmployee: EBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EmployeeId { get; set; }
        
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [ForeignKey("Position")]
        public int PositionId { get; set; }
        
        [StringLength(6)]
        public string EmployeeColor { get; set; }



        [StringLength(50)]
        public string EmployeeNumber { get; set; }

        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }
        
        [StringLength(250)]
        public string LastName { get; set; }


        
        [StringLength(250)]
        public string MiddleName { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Department { get; set; }

        public virtual ECompany Company { get; set; }
        public virtual EPosition Position { get; set; }

        public virtual ICollection<EPeripheral> Peripherals { get; set; }
    }
}
