using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonCRMFunction
{
    public class FAsset : IFAsset
    {
        private IDAsset _iDAsset;

        public FAsset()
        {
            _iDAsset = new DAsset();
        }

        #region CREATE
        public Asset Create(int createdBy, Asset asset)
        {
            EAsset eAsset = EAsset(asset);
            eAsset.CreatedDate = DateTime.Now;
            eAsset.CreatedBy = createdBy;

            eAsset = _iDAsset.Create(eAsset);

            CreateAssetHistory(createdBy, eAsset);

            return (Asset(eAsset));
        }

        private void CreateAssetHistory(int createdBy, EAsset eAsset)
        {

            EAssetHistory eAssetHistory = new EAssetHistory
            {
                CreatedDate = DateTime.Now,
                DateAssigned = DateTime.Now,

                CreatedBy = createdBy,
                EmployeeId = eAsset.EmployeeId,
                AssetId = eAsset.AssetId
            };
            _iDAsset.Create(eAssetHistory);
        }
        #endregion

        #region READ
        public Asset Read(int assetId)
        {
            EAsset eAsset = _iDAsset.Read<EAsset>(a => a.AssetId == assetId);
            return Asset(eAsset);
        }

        public List<Asset> Read()
        {
            List<EAsset> eAsset = _iDAsset.List<EAsset>(a => true);
            return Assets(eAsset);
        }

        public List<Asset> Read(int employeeId, string sortBy)
        {
            List<EAsset> eAssets = _iDAsset.Read<EAsset>(a => a.EmployeeId == employeeId, sortBy);
            return Assets(eAssets);
        }

        #endregion

        #region UPDATE
        public Asset Update(int updatedBy, Asset asset)
        {
            EAsset currentAsset = _iDAsset.Read<EAsset>(a => a.AssetId == asset.AssetId);

            var eAsset = EAsset(asset);
            eAsset.UpdatedDate = DateTime.Now;
            eAsset.UpdatedBy = updatedBy;
            eAsset = _iDAsset.Update(EAsset(asset));

            if (asset.EmployeeId != currentAsset.EmployeeId)
                CreateAssetHistory(updatedBy, eAsset);

            return (Asset(eAsset));
        }
        #endregion

        #region DELETE
        public void Delete(int assetId)
        {
            _iDAsset.Delete<EAsset>(a => a.AssetId == assetId);
        }
        #endregion

        private List<Asset> Assets(List<EAsset> eAssets)
        {
            return eAssets.Select(a => new Asset
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                EmployeeId = a.EmployeeId,
                AssetId = a.AssetId,
                AssetTypeId = a.AssetTypeId,
                UpdatedBy = a.UpdatedBy,

                AssetTag = a.AssetTag,
                Description = a.Description,
                Name = a.Name,
                SerialNumber = a.SerialNumber
            }).ToList();
        }
        private EAsset EAsset(Asset asset)
        {
            return new EAsset
            {
                CreatedDate = asset.CreatedDate,
                UpdatedDate = asset.UpdatedDate,

                CreatedBy = asset.CreatedBy,
                EmployeeId = asset.EmployeeId,
                AssetId = asset.AssetId,
                AssetTypeId = asset.AssetTypeId,
                UpdatedBy = asset.UpdatedBy,

                AssetTag = asset.AssetTag,
                Description = asset.Description,
                Name = asset.Name,
                SerialNumber = asset.SerialNumber
            };
        }

        private Asset Asset(EAsset eAsset)
        {
            return new Asset
            {
                CreatedDate = eAsset.CreatedDate,
                UpdatedDate = eAsset.UpdatedDate,

                CreatedBy = eAsset.CreatedBy,
                EmployeeId = eAsset.EmployeeId,
                AssetId = eAsset.AssetId,
                AssetTypeId = eAsset.AssetTypeId,
                UpdatedBy = eAsset.UpdatedBy,

                AssetTag = eAsset.AssetTag,
                Description = eAsset.Description,
                Name = eAsset.Name,
                SerialNumber = eAsset.SerialNumber
            };
        }

        Asset IFAsset.Read(int assetId)
        {
            throw new NotImplementedException();
        }
    }
}