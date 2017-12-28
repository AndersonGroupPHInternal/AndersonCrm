using AndersonCRMContext;
using BaseData;

namespace AndersonCRMData
{
    public class DAssetHistory : DBase, IDAssetHistory
    {
        public DAssetHistory() : base(new Context())
        {
        }
    }
}