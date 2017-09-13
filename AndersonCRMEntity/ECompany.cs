using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("Company")]
    public class ECompany: EBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CompanyId { get; set; }

        [StringLength(6)]
        public string CompanyColor { get; set; }

        [Required]
        [StringLength(250)]
        public string CompanyName { get; set; }

        public virtual ICollection<EEmployee> Employees { get; set; }
    }
}
