using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class Company : Base.Base
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }


        
        public List<Employee> Employees { get; set; }
    }
}
