using BaseModel;
using System;
using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class EmployeeFilter : Base
    {
        public DateTime? DateHiredFrom { get; set; }
        public DateTime? DateHiredTo { get; set; }

        public String Name { get; set; }
        public bool isResigned { get; set; }
    }
}
