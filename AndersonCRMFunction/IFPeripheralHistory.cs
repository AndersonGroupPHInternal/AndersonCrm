using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFPeripheralHistory
    {
        #region CREATE
        PeripheralHistory Create(PeripheralHistory peripheralhistory);
        #endregion
        #region READ
        PeripheralHistory Read(int peripheralhistoryId);
        List<PeripheralHistory> List();
        List<PeripheralHistory> List(int peripheralId);
        #endregion
        #region UPDATE
        PeripheralHistory Update(PeripheralHistory peripheralhistory);
        #endregion
        #region DELETE
        void Delete(PeripheralHistory peripheralhistory);
        #endregion
    }
}

             