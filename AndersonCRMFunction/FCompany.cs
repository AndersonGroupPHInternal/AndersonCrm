using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;

namespace AndersonCRMFunction
{
    public class FCompany : IFCompany
    {
        private IDCompany _iDCompany;

        public FCompany()
        {
            _iDCompany = new DCompany();
        }

        #region CREATE
        public Company Create(Company company)
        {
            ECompany eCompany = ECompany(company);
            eCompany = _iDCompany.Create(eCompany);
            return (Company(eCompany));
        }
        #endregion

        #region READ
        public Company Read(int companyId)
        {
            ECompany eCompany = _iDCompany.Read<ECompany>(a => a.CompanyId == companyId);
            return Company(eCompany);
        }

        public Company Read(string companyName)
        {
            ECompany eCompany = _iDCompany.Read<ECompany>(a => a.CompanyName == companyName);
            return Company(eCompany);
        }

        public Company ReadDefault()
        {
            ECompany eCompany = _iDCompany.Read<ECompany>(a => a.CompanyName == "AndersonGroup");
            return Company(eCompany);
        }

        public List<Company> List()
        {
            List<ECompany> eCompanies = _iDCompany.List<ECompany>(a => true);
            return Companies(eCompanies);
        }
        #endregion

        #region UPDATE
        public Company Update(Company company)
        {
            var eCompany = _iDCompany.Update(ECompany(company));
            return (Company(eCompany));
        }
        #endregion

        #region DELETE
        public void Delete(Company company)
        {
            _iDCompany.Delete(ECompany(company));
        }
        #endregion
        #region OTHER FUNCTION
        private List<Company> Companies(List<ECompany> eCompanies)
        {
            var returnCompanies = eCompanies.Select(a => new Company
            {
                CompanyId = a.CompanyId,
             
                CompanyName = a.CompanyName,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy
            });

            return returnCompanies.ToList();
        }

        private ECompany ECompany(Company company)
        {
            ECompany returnECompany = new ECompany
            {
                CompanyId = company.CompanyId,
          
                CompanyName = company.CompanyName,
                CreatedBy = company.CreatedBy,
                UpdatedBy = company.UpdatedBy
            };
            return returnECompany;
        }

        private Company Company(ECompany eCompany)
        {
            Company returnCompany = new Company
            {
                CompanyId = eCompany.CompanyId,
              
                CompanyName = eCompany.CompanyName,
                CreatedBy = eCompany.CreatedBy,
                UpdatedBy = eCompany.UpdatedBy
            };
            return returnCompany;
        }
        #endregion
    }
}
