using AndersonCRMModel;
using AndersonCRMFunction;
using System.Collections.Generic;

namespace AndersonCRMStatic
{
    public static class SCompany
    {
        public static Company Insert(this Company company)
        {
            return FCompany().Insert(company);
        }

        public static Company Get(this Company company)
        {
            return FCompany().Get(company);
        }

        public static List<Company> List(this Company company)
        {
            return FCompany().List(company);
        }

        public static Company Set(this Company company)
        {
            return FCompany().Set(company);
        }

        public static void Delete(this Company company)
        {
            FCompany().Delete(company);
        }

        private static FCompany FCompany()
        {
            return new FCompany();
        }
    }
}
