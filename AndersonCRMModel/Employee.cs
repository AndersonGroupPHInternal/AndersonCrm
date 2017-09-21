using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class Employee : Base.Base
    {
        public int EmployeeId { get; set; }

        public int CompanyId { get; set; }

        public int? DepartmentId { get; set; }

        public int ManagerEmployeeId { get; set; }      

        public int PositionId { get; set; }
       



        public string FirstName { get; set; }


        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string JobTitle { get; set; }

        public string HiringDate { get; set; }

        public string StartingDate { get; set; }

        public string Team { get; set; }

        public Company Company { get; set; }
        public Position Position { get; set; }
        public Department Department { get; set; }

        public List<PeripheralHistory> PeripheralHistories { get; set; }
        public List<Peripheral> Peripherals { get; set; }

    }
}
