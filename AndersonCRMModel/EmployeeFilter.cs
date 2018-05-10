using BaseModel;
using System;

namespace AndersonCRMModel
{
    public class EmployeeFilter : Base
    {
        public string Name { get; set; }
        public bool isActive { get; set; }
        public bool isResigned { get; set; }
        public DateTime? DateHiredFrom { get; set; }
        public DateTime? DateHiredTo { get; set; }

     
    }
}
