using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFPeripheral
    {
        #region CREATE
        Peripheral Create(Peripheral peripheral);
        #endregion
        #region READ
        Peripheral Read(int peripheralId);
        List<Peripheral> List();
        List<Peripheral> List(int employeeId);
        #endregion
        #region UPDATE
        Peripheral Update(Peripheral peripheral);
        #endregion
        #region DELETE
        void Delete(Peripheral peripheral);
        #endregion
    }
}
