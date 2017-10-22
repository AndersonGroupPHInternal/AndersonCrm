using BaseModel;
using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class Department : Base
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<EmployeeDepartment> DepartmentEmployees { get; set; }
    }
}
