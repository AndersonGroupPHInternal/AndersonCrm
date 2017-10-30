using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonCRMFunction
{
    public class FTeam : IFTeam
    {
        private IDTeam _iDTeam;

        public FTeam()
        {
            _iDTeam = new DTeam();
        }

        #region CREATE
        public Team Create(int createdBy, Team team)
        {
            ETeam eTeam = ETeam(team);
            eTeam.CreatedDate = DateTime.Now;
            eTeam.CreatedBy = createdBy;
            eTeam = _iDTeam.Create(eTeam);
            return (Team(eTeam));
        }
        #endregion
        
        #region READ
        public Team Read(int teamId)
        {
            ETeam eTeam = _iDTeam.Read<ETeam>(a => a.TeamId == teamId);
            return Team(eTeam);
        }
        
        public List<Team> Read()
        {
            List<ETeam> eTeams = _iDTeam.List<ETeam>(a => true);
            return Teams(eTeams);
        }

        public List<Team> Read(int employeeId, string sortBy)
        {
            List<ETeam> eTeams = _iDTeam.Read<ETeam>(a => a.EmployeeTeams.Any(b => b.EmployeeId == employeeId), sortBy);
            return Teams(eTeams);
        }
        #endregion

        #region UPDATE
        public Team Update(int updatedBy, Team team)
        {
            var eTeam = ETeam(team);
            eTeam.UpdatedDate = DateTime.Now;
            eTeam.UpdatedBy = updatedBy;
            eTeam = _iDTeam.Update(ETeam(team));
            return (Team(eTeam));
        }
        #endregion

        #region DELETE
        public void Delete(int teamId)
        {
            _iDTeam.Delete<ETeam>(a => a.TeamId == teamId);
        }
        #endregion

        #region OTHER FUNCTION
        private List<Team> Teams(List<ETeam> eTeams)
        {
            return eTeams.Select(a => new Team
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                TeamId = a.TeamId,
                UpdatedBy = a.UpdatedBy,

                Color = "#" + a.Color,
                Name = a.Name
            }).ToList();
        }
        private ETeam ETeam(Team team)
        {
            return new ETeam
            {
                CreatedDate = team.CreatedDate,
                UpdatedDate = team.UpdatedDate,

                CreatedBy = team.CreatedBy,
                TeamId = team.TeamId,
                UpdatedBy = team.UpdatedBy,

                Color = team.Color.Trim(new Char[] { '#' }),
                Name = team.Name
            };
        }

        private Team Team(ETeam eTeam)
        {
            return new Team
            {
                CreatedDate = eTeam.CreatedDate,
                UpdatedDate = eTeam.UpdatedDate,
                
                CreatedBy = eTeam.CreatedBy,
                TeamId = eTeam.TeamId,
                UpdatedBy = eTeam.UpdatedBy,

                Color = "#" + eTeam.Color,
                Name = eTeam.Name
            };
        }
        #endregion
    }
}
