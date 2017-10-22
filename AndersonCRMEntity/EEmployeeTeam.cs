using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("EmployeeTeam")]
    public class EEmployeeTeam : EBase
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeTeamId { get; set; }
        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public virtual EEmployee Employee { get; set; }
        public virtual ETeam Team { get; set; }

    }
}
