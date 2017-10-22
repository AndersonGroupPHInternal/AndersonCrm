using BaseModel;

namespace AndersonCRMModel
{
    public class EmployeeTeam : Base
    {
        public int EmployeeId { get; set; }
        public int EmployeeTeamId { get; set; }
        public int TeamId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Team Team { get; set; }

    }
}
