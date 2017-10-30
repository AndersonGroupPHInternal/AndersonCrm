using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonCRMFunction
{
    public class FPeripheralType : IFPeripheralType
    {
        private IDPeripheralType _iDPeripheralType;

        public FPeripheralType()
        {
            _iDPeripheralType = new DPeripheralType();
        }

        #region CREATE
        public PeripheralType Create(int createdBy, PeripheralType peripheralType)
        {
            EPeripheralType ePeripheralType = EPeripheralType(peripheralType);
            ePeripheralType.CreatedDate = DateTime.Now;
            ePeripheralType.CreatedBy = createdBy;
            ePeripheralType = _iDPeripheralType.Create(ePeripheralType);
            return (PeripheralType(ePeripheralType));
        }
        #endregion
        
        #region READ
        public PeripheralType Read(int peripheralTypeId)
        {
            EPeripheralType ePeripheralType = _iDPeripheralType.Read<EPeripheralType>(a => a.PeripheralTypeId == peripheralTypeId);
            return PeripheralType(ePeripheralType);
        }
        
        public List<PeripheralType> Read()
        {
            List<EPeripheralType> ePeripheralTypes = _iDPeripheralType.List<EPeripheralType>(a => true);
            return PeripheralTypes(ePeripheralTypes);
        }
        #endregion

        #region UPDATE
        public PeripheralType Update(int updatedBy, PeripheralType peripheralType)
        {
            var ePeripheralType = EPeripheralType(peripheralType);
            ePeripheralType.UpdatedDate = DateTime.Now;
            ePeripheralType.UpdatedBy = updatedBy;
            ePeripheralType = _iDPeripheralType.Update(EPeripheralType(peripheralType));
            return (PeripheralType(ePeripheralType));
        }
        #endregion

        #region DELETE
        public void Delete(int peripheralTypeId)
        {
            _iDPeripheralType.Delete<EPeripheralType>(a => a.PeripheralTypeId == peripheralTypeId);
        }
        #endregion

        #region OTHER FUNCTION
        private List<PeripheralType> PeripheralTypes(List<EPeripheralType> ePeripheralTypes)
        {
            return ePeripheralTypes.Select(a => new PeripheralType
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                PeripheralTypeId = a.PeripheralTypeId,
                UpdatedBy = a.UpdatedBy,

                Color = "#" + a.Color,
                Name = a.Name
            }).ToList();
        }
        private EPeripheralType EPeripheralType(PeripheralType peripheralType)
        {
            return new EPeripheralType
            {
                CreatedDate = peripheralType.CreatedDate,
                UpdatedDate = peripheralType.UpdatedDate,

                CreatedBy = peripheralType.CreatedBy,
                PeripheralTypeId = peripheralType.PeripheralTypeId,
                UpdatedBy = peripheralType.UpdatedBy,

                Color = peripheralType.Color.Trim(new Char[] { '#' }),
                Name = peripheralType.Name
            };
        }

        private PeripheralType PeripheralType(EPeripheralType ePeripheralType)
        {
            return new PeripheralType
            {
                CreatedDate = ePeripheralType.CreatedDate,
                UpdatedDate = ePeripheralType.UpdatedDate,
                
                CreatedBy = ePeripheralType.CreatedBy,
                PeripheralTypeId = ePeripheralType.PeripheralTypeId,
                UpdatedBy = ePeripheralType.UpdatedBy,

                Color = "#" + ePeripheralType.Color,
                Name = ePeripheralType.Name
            };
        }
        #endregion
    }
}
