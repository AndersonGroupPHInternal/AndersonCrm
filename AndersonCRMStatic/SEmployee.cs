using AndersonCRMModel;
using AndersonCRMFunction;
using System.Collections.Generic;

namespace AndersonCRMStatic
{
    public static class SEmployee
    {
        public static Employee Insert(this Employee employee)
        {
            return FEmployee().Insert(employee);
        }

        public static Employee Get(this Employee employee)
        {
            return FEmployee().Get(employee);
        }

        public static List<Employee> List(this Employee employee)
        {
            return FEmployee().List(employee);
        }

        public static Employee Set(this Employee employee)
        {
            return FEmployee().Set(employee);
        }

        public static void Delete(this Employee employee)
        {
            FEmployee().Delete(employee);
        }

        private static FEmployee FEmployee()
        {
            return new FEmployee();
        }
    }
}
