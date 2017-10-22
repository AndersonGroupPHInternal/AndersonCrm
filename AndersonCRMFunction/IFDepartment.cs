using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFDepartment
    {
        #region CREATE
        Department Create(int createdBy, Department department);
        #endregion

        #region READ
        Department Read(int departmentId);
        List<Department> Read();
        List<Department> Read(int employeeId, string sortBy);
        #endregion

        #region UPDATE
        Department Update(int updatedBy, Department department);
        #endregion

        #region DELETE
        void Delete(int departmentId);
        #endregion
    }
}
