using AndersonCRMContext;
using BaseData;

namespace AndersonCRMData
{
    public class DPeripheralType : DBase, IDPeripheralType
    {
        public DPeripheralType() : base(new Context())
        {
        }
    }
}