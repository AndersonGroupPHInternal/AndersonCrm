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
        public Peripheral Create(int createdBy, Peripheral peripheral)
        {
            EPeripheral ePeripheral = EPeripheral(peripheral);
            ePeripheral.CreatedDate = DateTime.Now;
            ePeripheral.CreatedBy = createdBy;
            
            ePeripheral = _iDPeripheral.Create(ePeripheral);

            CreatePeripheralHistory(createdBy, ePeripheral);

            return (Peripheral(ePeripheral));
        }

        private void CreatePeripheralHistory(int createdBy, EPeripheral ePeripheral)
        {

            EPeripheralHistory ePeripheralHistory = new EPeripheralHistory
            {
                CreatedDate = DateTime.Now,
                DateAssigned = DateTime.Now,

                CreatedBy = createdBy,
                EmployeeId = ePeripheral.EmployeeId,
                PeripheralId = ePeripheral.PeripheralId
            };
            _iDPeripheral.Create(ePeripheralHistory);
        }
        #endregion

        #region READ
        public Peripheral Read(int peripheralId)
        {
            EPeripheral ePeripheral = _iDPeripheral.Read<EPeripheral>(a => a.PeripheralId == peripheralId);
            return Peripheral(ePeripheral);
        }

        public List<Peripheral> Read()
        {
            List<EPeripheral> ePeripherals = _iDPeripheral.List<EPeripheral>(a => true);
            return Peripherals(ePeripherals);
        }

        public List<Peripheral> Read(int employeeId, string sortBy)
        {
            List<EPeripheral> ePeripherals = _iDPeripheral.Read<EPeripheral>(a => a.EmployeeId == employeeId, sortBy);
            return Peripherals(ePeripherals);
        }

        #endregion

        #region UPDATE
        public Peripheral Update(int updatedBy, Peripheral peripheral)
        {
            EPeripheral currentPeripheral = _iDPeripheral.Read<EPeripheral>(a => a.PeripheralId == peripheral.PeripheralId);

            var ePeripheral = EPeripheral(peripheral);
            ePeripheral.UpdatedDate = DateTime.Now;
            ePeripheral.UpdatedBy = updatedBy;
            ePeripheral = _iDPeripheral.Update(EPeripheral(peripheral));

            if (peripheral.EmployeeId != currentPeripheral.EmployeeId)
                CreatePeripheralHistory(updatedBy, ePeripheral);

            return (Peripheral(ePeripheral));
        }
        #endregion

        #region DELETE
        public void Delete(int peripheralId)
        {
            _iDPeripheral.Delete<EPeripheral>(a => a.PeripheralId == peripheralId);
        }
        #endregion

        private List<Peripheral> Peripherals(List<EPeripheral> ePeripherals)
        {
            return ePeripherals.Select(a => new Peripheral
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                EmployeeId = a.EmployeeId,
                PeripheralId = a.PeripheralId,
                PeripheralTypeId = a.PeripheralTypeId,
                UpdatedBy = a.UpdatedBy,

                AssetTag = a.AssetTag,
                Description = a.Description,
                Name = a.Name,
                SerialNumber = a.SerialNumber
            }).ToList();
        }
        private EPeripheral EPeripheral(Peripheral peripheral)
        {
            return new EPeripheral
            {
                CreatedDate = peripheral.CreatedDate,
                UpdatedDate = peripheral.UpdatedDate,

                CreatedBy = peripheral.CreatedBy,
                EmployeeId = peripheral.EmployeeId,
                PeripheralId = peripheral.PeripheralId,
                PeripheralTypeId = peripheral.PeripheralTypeId,
                UpdatedBy = peripheral.UpdatedBy,

                AssetTag = peripheral.AssetTag,
                Description = peripheral.Description,
                Name = peripheral.Name,
                SerialNumber = peripheral.SerialNumber
            };
        }

        private Peripheral Peripheral(EPeripheral ePeripheral)
        {
            return new Peripheral
            {
                CreatedDate = ePeripheral.CreatedDate,
                UpdatedDate = ePeripheral.UpdatedDate,

                CreatedBy = ePeripheral.CreatedBy,
                EmployeeId = ePeripheral.EmployeeId,
                PeripheralId = ePeripheral.PeripheralId,
                PeripheralTypeId = ePeripheral.PeripheralTypeId,
                UpdatedBy = ePeripheral.UpdatedBy,

                AssetTag = ePeripheral.AssetTag,
                Description = ePeripheral.Description,
                Name = ePeripheral.Name,
                SerialNumber = ePeripheral.SerialNumber
            };
        }
    }
}