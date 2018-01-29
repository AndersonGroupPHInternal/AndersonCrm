using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFEmployeeTeam
    {
        #region CREATE
        void Create(int createdBy, int employeeId, List<EmployeeTeam> employeeTeams);
        #endregion

        #region READ
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion
    }
}
