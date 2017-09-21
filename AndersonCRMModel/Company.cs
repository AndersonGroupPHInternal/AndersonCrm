using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonCRMModel
{
    public class Company : Base.Base
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }


        
        public List<Employee> Employees { get; set; }
    }
}
