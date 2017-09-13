using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFEmployee
    {
        #region CREATE
        Employee Create(Employee employee);
        #endregion
        #region READ
        Employee Read(int employeeId);
        List<Employee> List();
        List<Employee> List(int companyId);
        #endregion
        #region UPDATE
        Employee Update(Employee employee);
        #endregion
        #region DELETE
        void Delete(Employee employee);
        #endregion
    }
}
