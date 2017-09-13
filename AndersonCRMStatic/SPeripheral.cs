using AndersonCRMModel;
using AndersonCRMFunction;
using System.Collections.Generic;

namespace AndersonCRMStatic
{
    public static class SPeripheral
    {
        public static Peripheral Insert(this Peripheral peripheral)
        {
            return FPeripheral().Insert(peripheral);
        }

        public static Peripheral Get(this Peripheral peripheral)
        {
            return FPeripheral().Get(peripheral);
        }

        public static List<Peripheral> List(this Peripheral peripheral)
        {
            return FPeripheral().List(peripheral);
        }

        public static Peripheral Set(this Peripheral peripheral)
        {
            return FPeripheral().Set(peripheral);
        }

        public static void Delete(this Peripheral peripheral)
        {
            FPeripheral().Delete(peripheral);
        }

        private static FPeripheral FPeripheral()
        {
            return new FPeripheral();
        }
    }
}
