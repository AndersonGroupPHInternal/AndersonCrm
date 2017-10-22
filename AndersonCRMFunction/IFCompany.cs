using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFCompany
    {
        #region CREATE
        Company Create(int createdBy, Company company);
        #endregion

        #region Read
        Company Read(int companyId);
        Company Read(string companyName);
        Company ReadDefaultCompany();
        List<Company> Read();
        #endregion

        #region UPDATE
        Company Update(int updatedBy, Company company);
        #endregion

        #region DELETE
        void Delete(int companyId);
        #endregion
    }
}
