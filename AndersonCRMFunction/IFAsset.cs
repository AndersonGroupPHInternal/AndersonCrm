using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFAsset
    {
        #region CREATE
        Asset Create(int createdBy, Asset asset);
        #endregion

        #region READ
        Asset Read(int assetId);
        List<Asset> Read();
        List<Asset> Read(int employeeId, string sortBy);
        #endregion

        #region UPDATE
        Asset Update(int updatedBy, Asset asset);
        #endregion

        #region DELETE
        void Delete(int assetId);
        #endregion
    }
}
