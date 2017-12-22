using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonCRMFunction
{
    public class FJobTitle : IFJobTitle
    {
        private IDJobTitle _iDJobTitle;

        public FJobTitle()
        {
            _iDJobTitle = new DJobTitle();
        }

        #region CREATE
        public JobTitle Create(int createdBy, JobTitle jobTitle)
        {
            EJobTitle eJobTitle = EJobTitle(jobTitle);
            eJobTitle.CreatedDate = DateTime.Now;
            eJobTitle.CreatedBy = createdBy;
            eJobTitle = _iDJobTitle.Create(eJobTitle);
            return (JobTitle(eJobTitle));
        }
        #endregion
        
        #region READ
        public JobTitle Read(int jobTitleId)
        {
            EJobTitle eJobTitle = _iDJobTitle.Read<EJobTitle>(a => a.JobTitleId == jobTitleId);
            return JobTitle(eJobTitle);
        }
        
        public List<JobTitle> Read()
        {
            List<EJobTitle> eJobTitles = _iDJobTitle.List<EJobTitle>(a => true);
            return JobTitles(eJobTitles);
        }
        #endregion

        #region UPDATE
        public JobTitle Update(int updatedBy, JobTitle jobTitle)
        {
            var eJobTitle = EJobTitle(jobTitle);
            eJobTitle.UpdatedDate = DateTime.Now;
            eJobTitle.UpdatedBy = updatedBy;
            eJobTitle = _iDJobTitle.Update(EJobTitle(jobTitle));
            return (JobTitle(eJobTitle));
        }
        #endregion

        #region DELETE
        public void Delete(int jobTitleId)
        {
            _iDJobTitle.Delete<EJobTitle>(a => a.JobTitleId == jobTitleId);
        #endregion
        }
        #region OTHER FUNCTION
        private List<JobTitle> JobTitles(List<EJobTitle> eJobTitles)
        {
            return eJobTitles.Select(a => new JobTitle
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                JobTitleId = a.JobTitleId,
                UpdatedBy = a.UpdatedBy,

                Color = "#" + a.Color,
                Name = a.Name
            }).ToList();
        }
        private EJobTitle EJobTitle(JobTitle jobTitle)
        {
            return new EJobTitle
            {
                CreatedDate = jobTitle.CreatedDate,
                UpdatedDate = jobTitle.UpdatedDate,

                CreatedBy = jobTitle.CreatedBy,
                JobTitleId = jobTitle.JobTitleId,
                UpdatedBy = jobTitle.UpdatedBy,

                Color = jobTitle.Color.Trim(new Char[] { '#' }),
                Name = jobTitle.Name
            };
        }

        private JobTitle JobTitle(EJobTitle eJobTitle)
        {
            return new JobTitle
            {
                CreatedDate = eJobTitle.CreatedDate,
                UpdatedDate = eJobTitle.UpdatedDate,
                
                CreatedBy = eJobTitle.CreatedBy,
                JobTitleId = eJobTitle.JobTitleId,
                UpdatedBy = eJobTitle.UpdatedBy,

                Color = "#" + eJobTitle.Color,
                Name = eJobTitle.Name
            };
        }
        #endregion
    }
}
