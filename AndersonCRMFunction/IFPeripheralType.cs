using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFPeripheralType
    {
        #region CREATE
        PeripheralType Create(int createdBy, PeripheralType peripheralType);
        #endregion

        #region READ
        PeripheralType Read(int peripheralTypeId);
        List<PeripheralType> Read();
        #endregion

        #region UPDATE
        PeripheralType Update(int updatedBy, PeripheralType peripheralType);
        #endregion

        #region DELETE
        void Delete(int peripheralTypeId);
        #endregion
    }
}
