using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFTeam
    {
        #region CREATE
        Team Create(int createdBy, Team team);
        #endregion

        #region READ
        Team Read(int teamId);
        List<Team> Read();
        List<Team> Read(int employeeId, string sortBy);
        #endregion

        #region UPDATE
        Team Update(int updatedBy, Team team);
        #endregion

        #region DELETE
        void Delete(int teamId);
        #endregion
    }
}
