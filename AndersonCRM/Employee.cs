using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class Employee :  Base.Base
    {
        public int CompanyId { get; set; }

        public int PositionId { get; set; }

        public string Color { get; set; }

        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public List<Peripheral> Peripherals { get; set; }

        public Position Position { get; set; }
    }
}
