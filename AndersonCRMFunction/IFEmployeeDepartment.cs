using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFEmployeeDepartment
    {
        #region CREATE
        void Create(int createdBy, int employeeId, List<EmployeeDepartment> employeeDepartments);
        #endregion

        #region READ
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion
    }
}
