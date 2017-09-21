using AndersonCRMContext;
using AndersonCRMEntity;
using BaseData;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace AndersonCRMData
{
    public class DPeripheral : DBase, IDPeripheral
    {
        public DPeripheral() : base(new Context())
        {
        }
        public List<EPeripheral> Read()
        {
            using (var context = new Context())
            {
                return context.Peripherals
                    .Include(a => a.Employee)
                    .ToList();
            }
        }
    }
}
