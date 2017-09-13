using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersonCRMModel
{
    public class Position : Base.Base
    {
        public int PositionId { get; set; }

        public string PositionName { get; set; }

   

        public List<Employee> Employees { get; set; }
    }
}
