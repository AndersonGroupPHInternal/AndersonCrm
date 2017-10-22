using BaseModel;

namespace AndersonCRMModel
{
    public class EmployeeDepartment : Base
    {
        public int DepartmentId { get; set; }
        public int EmployeeDepartmentId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
