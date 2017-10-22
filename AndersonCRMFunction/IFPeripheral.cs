using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFPeripheral
    {
        #region CREATE
        Peripheral Create(int createdBy, Peripheral peripheral);
        #endregion

        #region READ
        Peripheral Read(int peripheralId);
        List<Peripheral> Read();
        List<Peripheral> Read(int employeeId, string sortBy);
        #endregion

        #region UPDATE
        Peripheral Update(int updatedBy, Peripheral peripheral);
        #endregion

        #region DELETE
        void Delete(int peripheralId);
        #endregion
    }
}
