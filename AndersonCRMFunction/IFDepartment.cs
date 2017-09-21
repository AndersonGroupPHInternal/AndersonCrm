using AndersonCRMModel;
using System.Collections.Generic;

namespace AndersonCRMFunction
{
    public interface IFDepartment
    {
        #region CREATE
        Department Create(Department department);
        #endregion
        #region READ
        Department Read(int departmentId);
        Department Read(string description);
        List<Department> List();
        #endregion
        #region UPDATE
        Department Update(Department department);
        #endregion
        #region DELETE
        void Delete(Department department);
        #endregion
    }
}
