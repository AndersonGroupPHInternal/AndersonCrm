using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("Department")]
    public class EDepartment: EBase 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DepartmentId { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<EEmployee> Employees { get; set; }
    }
}
