using AndersonCRMContext;
using BaseData;

namespace AndersonCRMData
{
    public class DJobTitle : DBase, IDJobTitle
    {
        public DJobTitle() : base(new Context())
        {
        }
    }
}
