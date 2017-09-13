using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("Position")]
    public class EPosition: EBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PositionId { get; set; }

        [StringLength(6)]
        public string PositionColor { get; set; }

        [Required]
        [StringLength(250)]
        public string PositionName { get; set; }
        
    }
}
