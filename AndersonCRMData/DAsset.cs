using AndersonCRMContext;
using BaseData;


namespace AndersonCRMData
{
    public class DAsset : DBase, IDAsset
    {
        public DAsset() : base(new Context())
        {
        }
    }
}
