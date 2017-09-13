using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;

namespace AndersonCRMFunction
{
    public class FPosition : IFPosition
    {
        private IDPosition _iDPosition;

        public FPosition()
        {
            _iDPosition = new DPosition();
        }

        #region CREATE
        public Position Create(Position position)
        {
            //var ePosition = _iDPosition.Create(EPosition(position));

            //return (Position(ePosition));
            EPosition ePosition = EPosition(position);
            ePosition = _iDPosition.Create(ePosition);
            return (Position(ePosition));
        }
        #endregion
        #region READ
        public Position Read(int positionId)
        {
            EPosition ePosition = _iDPosition.Read<EPosition>(a => a.PositionId == positionId);
            return Position(ePosition);
        }
        
        public List<Position> List()
        {
            List<EPosition> ePositions = _iDPosition.List<EPosition>(a => true);
            return Positions(ePositions);
        }

        #endregion
        #region UPDATE
        public Position Update(Position position)
        {
            var ePosition = _iDPosition.Update(EPosition(position));
            return (Position(ePosition));
        }
        #endregion
        #region DELETE
        public void Delete(Position position)
        {
            _iDPosition.Delete(EPosition(position));
        }
        #endregion

        private List<Position> Positions(List<EPosition> ePositions)
        {
            var returnPositions = ePositions.Select(a => new Position
            {
                PositionId = a.PositionId,
            
                PositionName = a.PositionName,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy
            });

            return returnPositions.ToList();
        }
        private EPosition EPosition(Position position)
        {
            EPosition returnEPosition = new EPosition
            {
                PositionId = position.PositionId,
         
                PositionName = position.PositionName,
                CreatedBy = position.CreatedBy,
                UpdatedBy = position.UpdatedBy
            };
            return returnEPosition;
        }

        private Position Position(EPosition ePosition)
        {
            Position returnPosition = new Position
            {
                PositionId = ePosition.PositionId,
           
                PositionName = ePosition.PositionName,
                CreatedBy = ePosition.CreatedBy,
                UpdatedBy = ePosition.UpdatedBy
            };
            return returnPosition;
        }
    }
}
