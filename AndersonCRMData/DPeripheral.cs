using AndersonCRMContext;
using BaseData;


namespace AndersonCRMData
{
    public class DPeripheral : DBase, IDPeripheral
    {
        public DPeripheral() : base(new Context())
        {
        }
    }
}
