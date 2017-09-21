using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;

namespace AndersonCRMFunction
{
    public class FPeripheralHistory : IFPeripheralHistory
    {
        private IDPeripheralHistory _iDPeripheralHistory;

        public FPeripheralHistory()
        {
            _iDPeripheralHistory = new DPeripheralHistory();
        }

        #region CREATE
        public PeripheralHistory Create(PeripheralHistory peripheralhistory)
        {
            //var ePeripheral = _iDPeripheral.Create(EPeripheral(peripheral));

            //return (Peripheral(ePeripheral));
            EPeripheralHistory ePeripheralHistory = EPeripheralHistory(peripheralhistory);
            ePeripheralHistory = _iDPeripheralHistory.Create(ePeripheralHistory);
            return (PeripheralHistory(ePeripheralHistory));
        }
        #endregion

        #region READ
        public PeripheralHistory Read(int peripheralhistoryId)
        {
            EPeripheralHistory ePeripheralHistory = _iDPeripheralHistory.Read<EPeripheralHistory>(a => a.PeripheralHistoryId == peripheralhistoryId);
            return PeripheralHistory(ePeripheralHistory);
        }
        public List<PeripheralHistory> List()
        {
            List<EPeripheralHistory> ePeripheralHistories = _iDPeripheralHistory.List<EPeripheralHistory>(a => true);
            return PeripheralHistories(ePeripheralHistories);
        }

        public List<PeripheralHistory> List(int peripheralId)
        {
            List<EPeripheralHistory> ePeripheralHistories = _iDPeripheralHistory.List<EPeripheralHistory>(a => a.PeripheralId == peripheralId);
            return PeripheralHistories(ePeripheralHistories);
        }

        #endregion

        #region UPDATE
        public PeripheralHistory Update(PeripheralHistory peripheralhistory)
        {
            var ePeripheralHistory = _iDPeripheralHistory.Update(EPeripheralHistory(peripheralhistory));
            return (PeripheralHistory(ePeripheralHistory));
        }
        #endregion

        #region DELETE
        public void Delete(PeripheralHistory peripheralhistory)
        {
            _iDPeripheralHistory.Delete(EPeripheralHistory(peripheralhistory));
        }
        #endregion

        private List<PeripheralHistory> PeripheralHistories(List<EPeripheralHistory> ePeripheralHistories)
        {
            var returnPeripheralHistories = ePeripheralHistories.Select(a => new PeripheralHistory
            {
                PeripheralId = a.PeripheralId,
                EmployeeId = a.EmployeeId,
                PeripheralHistoryId = a.PeripheralHistoryId,
                Date = a.Date,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy,
                Peripheral = new Peripheral
                {
                    PeripheralName = a.Peripheral.PeripheralName
                },
                Employee = new Employee
                {                                   
                   FirstName = a.Employee.FirstName,
                   MiddleName = a.Employee.MiddleName,
                   LastName = a.Employee.LastName
                }

            });

            return returnPeripheralHistories.ToList();
        }
        private EPeripheralHistory EPeripheralHistory(PeripheralHistory peripheralhistory)
        {
            EPeripheralHistory returnEPeripheralHistory = new EPeripheralHistory
            {
                PeripheralHistoryId = peripheralhistory.PeripheralHistoryId,

                PeripheralId = peripheralhistory.PeripheralId,
                EmployeeId = peripheralhistory.EmployeeId,
                Date = peripheralhistory.Date,

                CreatedBy = peripheralhistory.CreatedBy,
                UpdatedBy = peripheralhistory.UpdatedBy
            };
            return returnEPeripheralHistory;
        }

        private PeripheralHistory PeripheralHistory(EPeripheralHistory ePeripheralHistory)
        {
            PeripheralHistory returnPeripheralHistory = new PeripheralHistory
            {
                PeripheralHistoryId = ePeripheralHistory.PeripheralHistoryId,

                PeripheralId = ePeripheralHistory.PeripheralId,
                EmployeeId = ePeripheralHistory.EmployeeId,
                Date = ePeripheralHistory.Date,

                CreatedBy = ePeripheralHistory.CreatedBy,
                UpdatedBy = ePeripheralHistory.UpdatedBy
            };
            return returnPeripheralHistory;
        }
    }
}