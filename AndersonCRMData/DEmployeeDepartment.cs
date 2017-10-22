using AndersonCRMContext;
using BaseData;

namespace AndersonCRMData
{
    public class DEmployeeDepartment : DBase, IDEmployeeDepartment
    {
        public DEmployeeDepartment() : base(new Context())
        {
        }
    }
}
