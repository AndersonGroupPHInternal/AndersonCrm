using BaseModel;
using System;
using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class Asset : Base
    {

        public int EmployeeId { get; set; }
        public int AssetId { get; set; }
        public int AssetTypeId { get; set; }

        public string Manager { get; set; }
        public string AssetTag { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual AssetType AssetType { get; set; }

        public virtual ICollection<AssetHistory> AssetHistories { get; set; }
    }

}
