﻿using AndersonCRMModel;
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
            var eEmployeeDepartments = EEmployeeDepartments(createdBy, employeeId, employeeDepartments);
            _iDEmployeeDepartment.Create(eEmployeeDepartments);
        }
        #endregion

        #region READ
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
        #endregion
    }
}
