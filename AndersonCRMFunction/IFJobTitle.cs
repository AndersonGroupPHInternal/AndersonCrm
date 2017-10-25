using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFJobTitle
    {
        #region CREATE
        JobTitle Create(int createdBy, JobTitle jobTitle);
        #endregion

        #region READ
        JobTitle Read(int jobTitleId);
        List<JobTitle> Read();
        #endregion

        #region UPDATE
        JobTitle Update(int updatedBy, JobTitle jobTitle);
        #endregion

        #region DELETE
        void Delete(int jobTitleId);
        #endregion
    }
}
