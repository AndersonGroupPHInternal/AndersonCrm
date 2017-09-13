using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonCRMModel
{
    public class Peripheral :  Base.Base
    {
        public int EmployeeId { get; set; }

        public string Color { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SerialNumber { get; set; }
    }
}
