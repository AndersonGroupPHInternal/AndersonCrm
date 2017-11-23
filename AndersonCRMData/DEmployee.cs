using AndersonCRMContext;
using BaseData;

namespace AndersonCRMData
{
    public class DEmployee : DBase, IDEmployee
    {
        public DEmployee() :base(new Context())
        {
        }
    }
}
