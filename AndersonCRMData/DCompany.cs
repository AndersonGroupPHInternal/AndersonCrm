using AndersonCRMContext;
using BaseData;

namespace AndersonCRMData
{
    public class DCompany : DBase, IDCompany
    {
        public DCompany() : base(new Context())
        {
        }
    }
}
