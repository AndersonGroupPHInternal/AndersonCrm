using BaseModel;
using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class JobTitle : Base
    {
        public int JobTitleId { get; set; }
        
        public string Color { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}
