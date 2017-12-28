using BaseEntity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("AssetHistory")]
    public class EAssetHistory : EBase
    {
        public DateTime DateAssigned { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetHistoryId { get; set; }
        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        public virtual EEmployee Employee { get; set; }
        public virtual EAsset Asset { get; set; }

    }
}