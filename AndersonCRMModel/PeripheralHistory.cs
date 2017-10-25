using BaseModel;
using System;

namespace AndersonCRMModel
{
    public class PeripheralHistory : Base
    {
        public DateTime DateAssigned { get; set; }
        
        public int EmployeeId { get; set; }
        public int PeripheralHistoryId { get; set; }
        public int PeripheralId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Peripheral Peripheral { get; set; }
    }
}
