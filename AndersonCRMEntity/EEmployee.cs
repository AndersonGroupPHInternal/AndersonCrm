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

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        [ForeignKey("Position")]
        public int PositionId { get; set; }
     
        public int ManagerEmployeeId { get; set; }



        [StringLength(250)]
        public string FirstName { get; set; }
        
        [StringLength(250)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string JobTitle { get; set; }

        [StringLength(50)]
        public string HiringDate { get; set; }

        [StringLength(50)]
        public string StartingDate { get; set; }

        [StringLength(50)]
        public string Team { get; set; }

        public virtual ECompany Company { get; set; }
        public virtual EPosition Position { get; set; }
        public virtual EDepartment Department { get; set;  }

        public virtual ICollection<EPeripheralHistory> PeripheralHistories { get; set; }
        public virtual ICollection<EPeripheral> Peripherals { get; set; }
    }
}