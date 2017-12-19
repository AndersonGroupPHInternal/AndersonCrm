using BaseModel;
using System;
using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class Peripheral : Base
    {

        public int EmployeeId { get; set; }
        public int PeripheralId { get; set; }
        public int PeripheralTypeId { get; set; }

        public string Manager { get; set; }
        public string AssetTag { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual PeripheralType PeripheralType { get; set; }

        public virtual ICollection<PeripheralHistory> PeripheralHistories { get; set; }
    }

}
