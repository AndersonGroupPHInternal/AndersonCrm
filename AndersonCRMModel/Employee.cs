using BaseModel;
using System;
using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class Employee : Base
    {
        public DateTime DateHired { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }

        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public int JobTitleId { get; set; }
        public int ManagerEmployeeId { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public virtual Company Company { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public virtual Team Team { get; set; }

        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
        public virtual ICollection<EmployeeTeam> EmployeeTeams { get; set; }
        public virtual ICollection<Peripheral> Peripherals { get; set; }
        public virtual ICollection<PeripheralHistory> PeripheralHistories { get; set; }
    }
}
