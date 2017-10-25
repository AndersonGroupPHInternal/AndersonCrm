using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("Team")]
    public class ETeam : EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        [StringLength(6)]
        public string Color { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public virtual ICollection<EEmployeeTeam> EmployeeTeams { get; set; }

    }
}
