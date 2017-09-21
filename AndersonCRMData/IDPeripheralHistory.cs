using AndersonCRMContext;
using AndersonCRMEntity;
using BaseData;
using System.Collections.Generic;

namespace AndersonCRMData
{
    public interface IDPeripheralHistory : IDBase
    {
        List<EPeripheralHistory> Read();
    }
}
