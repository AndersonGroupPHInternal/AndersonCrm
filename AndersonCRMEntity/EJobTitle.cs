using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("JobTitle")]
    public class EJobTitle : EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobTitleId { get; set; }

        [StringLength(6)]
        public string Color { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public virtual ICollection<EEmployee> Employees { get; set; }

    }
}
