using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFAssetType
    {
        #region CREATE
        AssetType Create(int createdBy, AssetType assetType);
        #endregion

        #region READ
        AssetType Read(int assetTypeId);
        List<AssetType> Read();
        #endregion

        #region UPDATE
        AssetType Update(int updatedBy, AssetType assetType);
        #endregion

        #region DELETE
        void Delete(int assetTypeId);
        #endregion
    }
}
