using AndersonCRMContext;
using AndersonCRMEntity;
using BaseData;
using System.Collections.Generic;

namespace AndersonCRMData
{
    public interface IDPeripheral : IDBase
    {
        List<EPeripheral> Read();
    }
}
