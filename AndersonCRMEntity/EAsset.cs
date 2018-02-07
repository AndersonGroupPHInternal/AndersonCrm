using BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonCRMEntity
{
    [Table("Asset")]
    public class EAsset : EBase
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetId { get; set; }
        [ForeignKey("AssetType")]
        public int AssetTypeId { get; set; }


        [StringLength(50)]
        public string AssetTag { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string SerialNumber { get; set; }

        public virtual EEmployee Employee { get; set; }
        public virtual EAssetType AssetType { get; set; }

        public virtual ICollection<EAssetHistory> AssetHistories { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
