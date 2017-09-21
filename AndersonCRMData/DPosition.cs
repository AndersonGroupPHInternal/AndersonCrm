using AndersonCRMContext;
using BaseData;

namespace AndersonCRMData
{
    public class DPosition : DBase, IDPosition
    {
        public DPosition() : base(new Context())
        {
        }
    }
}
    