using AndersonCRMContext;
using BaseData;

namespace AndersonCRMData
{
    public class DPeripheralHistory : DBase, IDPeripheralHistory
    {
        public DPeripheralHistory() : base(new Context())
        {
        }
    }
}