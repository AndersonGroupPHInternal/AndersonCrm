using AndersonCRMContext;
using BaseData;

namespace AndersonCRMData
{
    public class DAssetType : DBase, IDAssetType
    {
        public DAssetType() : base(new Context())
        {
        }
    }
}