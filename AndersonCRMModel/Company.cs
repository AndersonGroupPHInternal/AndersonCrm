using BaseModel;
using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class Company : Base
    {
        public int CompanyId { get; set; }
        
        public string Color { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
