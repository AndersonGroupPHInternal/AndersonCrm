using BaseModel;
using System;

namespace AndersonCRMModel
{
    public class AssetHistory : Base
    {
        public DateTime DateAssigned { get; set; }
        
        public int EmployeeId { get; set; }
        public int AssetHistoryId { get; set; }
        public int AssetId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Asset Asset { get; set; }
    }
}
