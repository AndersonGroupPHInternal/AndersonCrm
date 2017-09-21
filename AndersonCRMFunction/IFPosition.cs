using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFPosition
    {
        #region CREATE
        Position Create(Position position);
        #endregion
        #region READ
        Position Read(int positionId);
        Position Read(string positionName);
        List<Position> List();
        #endregion
        #region UPDATE
        Position Update(Position position);
        #endregion
        #region DELETE
        void Delete(Position position);
        #endregion
    }
}
