using AndersonCRMContext;
using BaseData;

namespace AndersonCRMData
{
    public class DTeam : DBase, IDTeam
    {
        public DTeam() : base(new Context())
        {
        }
    }
}
    