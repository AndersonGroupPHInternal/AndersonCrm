using BaseModel;
using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class PeripheralType : Base
    {
        public int PeripheralTypeId { get; set; }

        public string Color { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Peripheral> Peripherals { get; set; }
    }
}
