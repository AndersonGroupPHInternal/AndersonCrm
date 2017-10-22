using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("Company")]
    public class ECompany: EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        [StringLength(6)]
        public string Color { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public virtual ICollection<EEmployee> Employees { get; set; }
    }
}
