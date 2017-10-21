using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonCRMFunction
{
    public class FPeripheral : IFPeripheral
    {
        private IDPeripheral _iDPeripheral;

        public FPeripheral()
        {
            _iDPeripheral = new DPeripheral();
        }

        #region CREATE
        public Peripheral Create(Peripheral peripheral)
        {
            //var ePeripheral = _iDPeripheral.Create(EPeripheral(peripheral));

            //return (Peripheral(ePeripheral));
            EPeripheral ePeripheral = EPeripheral(peripheral);
            ePeripheral = _iDPeripheral.Create(ePeripheral);

            EPeripheralHistory ePeripheralHistory = new EPeripheralHistory
            {
                CreatedDate = DateTime.Now,
                Date = ePeripheral.Date,
                EmployeeId = ePeripheral.EmployeeId,
                PeripheralId = ePeripheral.PeripheralId
            };

            _iDPeripheral.Create(ePeripheralHistory);
            return (Peripheral(ePeripheral));  
        }   
        #endregion

        #region READ
        public Peripheral Read(int peripheralId)
        {
            EPeripheral ePeripheral = _iDPeripheral.Read<EPeripheral>(a => a.PeripheralId == peripheralId);
            return Peripheral(ePeripheral);
        }

        public List<Peripheral> List()
        {
            List<EPeripheral> ePeripherals = _iDPeripheral.List<EPeripheral>(a => true);
            return Peripherals(ePeripherals);
        }

        public List<Peripheral> List(int employeeId)
        {
            List<EPeripheral> ePeripherals = _iDPeripheral.List<EPeripheral>(a => a.EmployeeId == employeeId);
            return Peripherals(ePeripherals);
        }

        #endregion

        #region UPDATE
        public Peripheral Update(Peripheral peripheral)
        {
            EPeripheral currentPeripheral = _iDPeripheral.Read<EPeripheral>(a => a.PeripheralId == peripheral.PeripheralId);
            var ePeripheral = _iDPeripheral.Update(EPeripheral(peripheral));
            if (peripheral.EmployeeId != currentPeripheral.EmployeeId)
            {
                EPeripheralHistory ePeripheralHistory = new EPeripheralHistory
                {
                    CreatedDate = DateTime.Now,
                    Date = ePeripheral.Date,
                    EmployeeId = ePeripheral.EmployeeId,
                    PeripheralId = ePeripheral.PeripheralId,
                    
                };

                _iDPeripheral.Create(ePeripheralHistory);
            }
            return (Peripheral(ePeripheral));
        }
        #endregion

        #region DELETE
        public void Delete(Peripheral peripheral)
        {
            _iDPeripheral.Delete(EPeripheral(peripheral));
        }
        #endregion

        private List<Peripheral> Peripherals(List<EPeripheral> ePeripherals)
        {
            var returnPeripherals = ePeripherals.Select(a => new Peripheral
            {
                PeripheralId = a.PeripheralId,
                EmployeeId = a.EmployeeId,
                PeripheralColor = a.PeripheralColor,
                PeripheralName = a.PeripheralName,
                Description = a.Description,
                SerialNumber = a.SerialNumber,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy,
                AssetTag = a.AssetTag,
                Date = a.Date,
                Employee = new Employee
                {                                   
                   FirstName = a.Employee.FirstName,
                   MiddleName = a.Employee.MiddleName,
                   LastName = a.Employee.LastName
                }
            });

            return returnPeripherals.ToList();
        }
        private EPeripheral EPeripheral(Peripheral peripheral)
        {
            EPeripheral returnEPeripheral = new EPeripheral
            {
                PeripheralId = peripheral.PeripheralId,
                EmployeeId = peripheral.EmployeeId,
                PeripheralColor = peripheral.PeripheralColor,
                PeripheralName = peripheral.PeripheralName,
                Description = peripheral.Description,
                SerialNumber = peripheral.SerialNumber,
                CreatedBy = peripheral.CreatedBy,
                UpdatedBy = peripheral.UpdatedBy,
                AssetTag=peripheral.AssetTag,
                Date = peripheral.Date
            };
            return returnEPeripheral;
        }

        private Peripheral Peripheral(EPeripheral ePeripheral)
        {
            Peripheral returnPeripheral = new Peripheral
            {
                PeripheralId = ePeripheral.PeripheralId,
                EmployeeId = ePeripheral.EmployeeId,
                PeripheralColor = ePeripheral.PeripheralColor,
                PeripheralName = ePeripheral.PeripheralName,
                Description = ePeripheral.Description,
                SerialNumber = ePeripheral.SerialNumber,
                CreatedBy = ePeripheral.CreatedBy,
                UpdatedBy = ePeripheral.UpdatedBy,
                AssetTag=ePeripheral.AssetTag,
                Date = ePeripheral.Date
            };
            return returnPeripheral;
        }
    }
}
