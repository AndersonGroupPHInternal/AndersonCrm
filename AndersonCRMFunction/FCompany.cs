using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;
using System;

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
        public Company Create(int createdBy, Company company)
        {
            ECompany eCompany = ECompany(company);
            eCompany.CreatedDate = DateTime.Now;
            eCompany.CreatedBy = createdBy;
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
            ECompany eCompany = _iDCompany.Read<ECompany>(a => a.Name == companyName);
            return Company(eCompany);
        }

        public Company ReadDefaultCompany()
        {
            ECompany eCompany = _iDCompany.Read<ECompany>(a => a.Name == "AndersonGroupPH");
            return Company(eCompany);
        }

        public List<Company> Read()
        {
            List<ECompany> eCompanies = _iDCompany.List<ECompany>(a => true);
            return Companies(eCompanies);
        }
        #endregion

        #region UPDATE
        public Company Update(int updatedBy, Company company)
        {
            ECompany eCompany = ECompany(company);
            eCompany.UpdatedDate = DateTime.Now;
            eCompany.UpdatedBy = updatedBy;
            eCompany = _iDCompany.Update(eCompany);
            return (Company(eCompany));
        }
        #endregion

        #region DELETE
        public void Delete(int companyId)
        {
            _iDCompany.Delete<ECompany>(a => a.CompanyId == companyId);
        }
        #endregion

        #region OTHER FUNCTION
        private List<Company> Companies(List<ECompany> eCompanies)
        {
            return eCompanies.Select(a => new Company
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CompanyId = a.CompanyId,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy,

                Color = "#" + a.Color,
                Name = a.Name,
            }).ToList();
        }

        private ECompany ECompany(Company company)
        {
            return new ECompany
            {
                CreatedDate = company.CreatedDate,
                UpdatedDate = company.UpdatedDate,

                CompanyId = company.CompanyId,
                CreatedBy = company.CreatedBy,
                UpdatedBy = company.UpdatedBy,

                Color = company.Color.Trim(new Char[] { '#' }),
                Name = company.Name,
            };
        }

        private Company Company(ECompany eCompany)
        {
            return new Company
            {
                CreatedDate = eCompany.CreatedDate,
                UpdatedDate = eCompany.UpdatedDate,

                CompanyId = eCompany.CompanyId,
                CreatedBy = eCompany.CreatedBy,
                UpdatedBy = eCompany.UpdatedBy,

                Color = "#" + eCompany.Color,
                Name = eCompany.Name,
            };
        }
        #endregion
    }
}
