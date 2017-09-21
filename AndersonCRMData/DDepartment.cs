using AndersonCRMContext;
using BaseData;

namespace AndersonCRMData
{
    public class DDepartment : DBase, IDDepartment
    {
        public DDepartment() : base(new Context())
        {
        }
    }
}
