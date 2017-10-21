using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class Department : Base.Base
    {
        public int DepartmentId { get; set; }

        public string Description { get; set; }

        public string DepartmentColor { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
