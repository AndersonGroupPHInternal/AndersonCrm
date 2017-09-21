using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonCRMModel
{
    public class PeripheralHistory : Base.Base
    {
 
        public int PeripheralHistoryId { get; set; }

        public int PeripheralId { get; set; }

        public int EmployeeId { get; set; }

        public string Date { get; set; }




        public Peripheral Peripheral { get; set; }
        public Employee Employee { get; set; }

    }
}
