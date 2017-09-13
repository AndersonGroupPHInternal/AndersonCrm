using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class Position : Base
    {
        public string Color { get; set; }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
