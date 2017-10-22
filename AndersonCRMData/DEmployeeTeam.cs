using AndersonCRMContext;
using BaseData;

namespace AndersonCRMData
{
    public class DEmployeeTeam : DBase, IDEmployeeTeam
    {
        public DEmployeeTeam() : base(new Context())
        {
        }
    }
}
