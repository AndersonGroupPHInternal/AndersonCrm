using AndersonCRMContext;
using AndersonCRMEntity;
using BaseData;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AndersonCRMData
{
    public class DEmployee : DBase, IDEmployee
    {
        public DEmployee() : base(new Context())
        {
        }

        public List<EEmployee> Read()
        {
            using (var context = new Context())
            {
                return context.Employees
                    .Include(a => a.Company)
                    .Include(a => a.Position)
                    .ToList();
            }
        }
    }
}
