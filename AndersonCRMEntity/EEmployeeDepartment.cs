using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("DepartmentEmployee")]
    public class EEmployeeDepartment : EBase
    {
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeDepartmentId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public virtual EDepartment Department { get; set; }
        public virtual EEmployee Employee { get; set; }
    }
}
