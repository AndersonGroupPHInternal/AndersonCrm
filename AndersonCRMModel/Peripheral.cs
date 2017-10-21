using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class Peripheral : Base.Base
    {
        public int PeripheralId { get; set; }

        public int EmployeeId { get; set; }

        public string PeripheralColor { get; set; }

        public string PeripheralName { get; set; }

        public string Description { get; set; }

        public string SerialNumber { get; set; }

        public string AssetTag { get; set; }

        public string Date { get; set; }



        public List<PeripheralHistory> PeripheralHistories { get; set; }
        public Employee Employee { get; set; }
    }

}
