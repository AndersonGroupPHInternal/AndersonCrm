using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFCompany
    {
        #region CREATE
        Company Create(Company company);
        #endregion
        #region RETRIEVE
        Company Read(int companyId);
        Company Read(string companyName);
        Company ReadDefault();
        List<Company> List();
        #endregion
        #region UPDATE
        Company Update(Company company);
        #endregion
        #region DELETE
        void Delete(Company company);
        #endregion
    }
}
