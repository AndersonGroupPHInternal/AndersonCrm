using BaseModel;
using System;
using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class EmployeeFilter : Base
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public String Name { get; set; }
    }
}
