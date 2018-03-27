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
        public String Status { get; set; }
        public bool isActived { get; set; }
        public bool isResigned { get; set; }
        public bool isActivedResigned { get; set; }
    }
}
