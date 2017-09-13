using AndersonCRMModel;
using AndersonCRMFunction;
using System.Collections.Generic;

namespace AndersonCRMStatic
{
    public static class SPosition
    {
        public static Position Insert(this Position position)
        {
            return FPosition().Insert(position);
        }

        public static Position Get(this Position position)
        {
            return FPosition().Get(position);
        }

        public static List<Position> List(this Position position)
        {
            return FPosition().List(position);
        }

        public static Position Set(this Position position)
        {
            return FPosition().Set(position);
        }

        public static void Delete(this Position position)
        {
            FPosition().Delete(position);
        }

        private static FPosition FPosition()
        {
            return new FPosition();
        }
    }
}
