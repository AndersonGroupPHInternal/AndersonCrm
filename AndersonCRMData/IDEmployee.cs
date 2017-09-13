using AndersonCRMContext;
using AndersonCRMEntity;
using BaseData;
using System.Collections.Generic;

namespace AndersonCRMData
{
    public interface IDEmployee : IDBase
    {
        List<EEmployee> Read();
    }
}
