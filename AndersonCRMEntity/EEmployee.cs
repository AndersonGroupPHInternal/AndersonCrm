using BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("Employee")]
    public class EEmployee: EBase
    {
        public DateTime DateHired { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [ForeignKey("JobTitle")]
        public int JobTitleId { get; set; }
        public int ManagerEmployeeId { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(250)]
        public string FirstName { get; set; }        
        [StringLength(250)]
        public string LastName { get; set; }
        [StringLength(250)]
        public string MiddleName { get; set; }

        public virtual ECompany Company { get; set; }
        public virtual EJobTitle JobTitle { get; set; }
        public virtual ETeam Team { get; set; }

        public virtual ICollection<EEmployeeDepartment> EmployeeDepartments { get; set; }
        public virtual ICollection<EEmployeeTeam> EmployeeTeams { get; set; }
        public virtual ICollection<EPeripheral> Peripherals { get; set; }
        public virtual ICollection<EPeripheralHistory> PeripheralHistories { get; set; }
    }
}