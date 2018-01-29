using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonCRMFunction
{
    public class FEmployeeTeam : IFEmployeeTeam
    {
        private IDEmployeeTeam _iDEmployeeTeam;

        public FEmployeeTeam()
        {
            _iDEmployeeTeam = new DEmployeeTeam();
        }

        #region CREATE
        public void Create(int createdBy, int employeeId, List<EmployeeTeam> employeeTeams)
        {
            Delete(employeeId);
            var eEmployeeTeams = EEmployeeTeams(createdBy, employeeId, employeeTeams);
            _iDEmployeeTeam.Create(eEmployeeTeams);
        }
        #endregion
        
        #region READ
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        private void Delete(int employeeId)
        {
            _iDEmployeeTeam.Delete<EEmployeeTeam>(a => a.EmployeeId == employeeId);
        }
        #endregion

        #region OTHER FUNCTION
        private List<EEmployeeTeam> EEmployeeTeams(int createdBy, int employeeId, List<EmployeeTeam> employeeTeams)
        {
            return employeeTeams.Select(a => new EEmployeeTeam
            {
                CreatedDate = DateTime.Now,

                CreatedBy = createdBy,
                TeamId = a.TeamId,
                EmployeeId = employeeId
            }).ToList();
        }
        #endregion
    }
}
