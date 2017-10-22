using BaseModel;
using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class Team : Base
    {
        public int TeamId { get; set; }
        
        public string Color { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}
