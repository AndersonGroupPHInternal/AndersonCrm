using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonCRMFunction
{
    public class FEmployeeDepartment : IFEmployeeDepartment
    {
        private IDEmployeeDepartment _iDEmployeeDepartment;

        public FEmployeeDepartment()
        {
            _iDEmployeeDepartment = new DEmployeeDepartment();
        }

        #region CREATE
        public void Create(int createdBy, int employeeId, List<EmployeeDepartment> employeeDepartments)
        {
            Delete(employeeId);
            if (!employeeDepartments?.Any() ?? true)
                return;
            var eEmployeeDepartments = EEmployeeDepartments(createdBy, employeeId, employeeDepartments);
            _iDEmployeeDepartment.Create(eEmployeeDepartments);
        }
        #endregion

        #region READ
        public List<EmployeeDepartment> Read(List<int> departmentIds)
        {
            List<EEmployeeDepartment> eEmployeeDepartments = _iDEmployeeDepartment.List<EEmployeeDepartment>(a => departmentIds.Contains(a.DepartmentId));
            return EmployeeDepartment(eEmployeeDepartments);
        }

        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        private void Delete(int employeeId)
        {
            _iDEmployeeDepartment.Delete<EEmployeeDepartment>(a => a.EmployeeId == employeeId);
        }
        #endregion

        #region OTHER FUNCTION
        private List<EEmployeeDepartment> EEmployeeDepartments(int createdBy, int employeeId, List<EmployeeDepartment> employeeDepartments)
        {
            return employeeDepartments.Select(a => new EEmployeeDepartment
            {
                CreatedDate = DateTime.Now,

                CreatedBy = createdBy,
                DepartmentId = a.DepartmentId,
                EmployeeId = employeeId
            }).ToList();
        }
        private List<EmployeeDepartment> EmployeeDepartment(List<EEmployeeDepartment> eEmployeeDepartments)
        {
            return eEmployeeDepartments.Select(a => new EmployeeDepartment
            {
                CreatedDate = a.CreatedDate,

                CreatedBy = a.CreatedBy,
                DepartmentId = a.DepartmentId,
                EmployeeId = a.EmployeeId
            }).ToList();
        }

        #endregion
    }
}
