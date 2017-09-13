using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonCRMModel
{
    public class Employee : Base.Base
    {
        public int EmployeeId { get; set; }

        public int CompanyId { get; set; }

        public int PositionId { get; set; }

        public string EmployeeNumber { get; set; }



        public string FirstName { get; set; }

        public string Email { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Department{ get; set; }

        public List<Peripheral> Peripherals { get; set; }

        public Company Company { get; set; }
        public Position Position { get; set; }
    }
}
