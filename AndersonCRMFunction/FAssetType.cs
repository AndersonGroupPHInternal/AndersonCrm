using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonCRMFunction
{
    public class FAssetType : IFAssetType
    {
        private IDAssetType _iDAssetType;

        public FAssetType()
        {
            _iDAssetType = new DAssetType();
        }

        #region CREATE
        public AssetType Create(int createdBy, AssetType assetType)
        {
            EAssetType eAssetType = EAssetType(assetType);
            eAssetType.CreatedDate = DateTime.Now;
            eAssetType.CreatedBy = createdBy;
            eAssetType = _iDAssetType.Create(eAssetType);
            return (AssetType(eAssetType));
        }
        #endregion
        
        #region READ
        public AssetType Read(int assetTypeId)
        {
            EAssetType eAssetType = _iDAssetType.Read<EAssetType>(a => a.AssetTypeId == assetTypeId);
            return AssetType(eAssetType);
        }
        
        public List<AssetType> Read()
        {
            List<EAssetType> eAssetTypes = _iDAssetType.List<EAssetType>(a => true);
            return AssetTypes(eAssetTypes);
        }
        #endregion

        #region UPDATE
        public AssetType Update(int updatedBy, AssetType assetType)
        {
            var eAssetType = EAssetType(assetType);
            eAssetType.UpdatedDate = DateTime.Now;
            eAssetType.UpdatedBy = updatedBy;
            eAssetType = _iDAssetType.Update(EAssetType(assetType));
            return (AssetType(eAssetType));
        }
        #endregion

        #region DELETE
        public void Delete(int assetTypeId)
        {
            _iDAssetType.Delete<EAssetType>(a => a.AssetTypeId == assetTypeId);
        }
        #endregion

        #region OTHER FUNCTION
        private List<AssetType> AssetTypes(List<EAssetType> eAssetTypes)
        {
            return eAssetTypes.Select(a => new AssetType
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                AssetTypeId = a.AssetTypeId,
                UpdatedBy = a.UpdatedBy,

                Color = "#" + a.Color,
                Name = a.Name
            }).ToList();
        }
        private EAssetType EAssetType(AssetType assetType)
        {
            return new EAssetType
            {
                CreatedDate = assetType.CreatedDate,
                UpdatedDate = assetType.UpdatedDate,

                CreatedBy = assetType.CreatedBy,
                AssetTypeId = assetType.AssetTypeId,
                UpdatedBy = assetType.UpdatedBy,

                Color = assetType.Color.Trim(new Char[] { '#' }),
                Name = assetType.Name
            };
        }

        private AssetType AssetType(EAssetType eAssetType)
        {
            return new AssetType
            {
                CreatedDate = eAssetType.CreatedDate,
                UpdatedDate = eAssetType.UpdatedDate,
                
                CreatedBy = eAssetType.CreatedBy,
                AssetTypeId = eAssetType.AssetTypeId,
                UpdatedBy = eAssetType.UpdatedBy,

                Color = "#" + eAssetType.Color,
                Name = eAssetType.Name
            };
        }
        #endregion
    }
}
