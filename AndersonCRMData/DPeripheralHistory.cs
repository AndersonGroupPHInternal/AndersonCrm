using AndersonCRMContext;
using AndersonCRMEntity;
using BaseData;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AndersonCRMData
{
    public class DPeripheralHistory : DBase, IDPeripheralHistory
    {
        public DPeripheralHistory() : base(new Context())
        {
        }
        public List<EPeripheralHistory> Read()
        {
            using (var context = new Context())
            {
                return context.PeripheralHistories
                    .Include(a => a.Peripheral)
                    .Include(a => a.Employee)
                    .ToList();
            }
        }
    }
}