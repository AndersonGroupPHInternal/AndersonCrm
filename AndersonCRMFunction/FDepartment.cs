using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonCRMFunction
{
    public class FDepartment : IFDepartment
    {
        private IDDepartment _iDDepartment;

        public FDepartment()
        {
            _iDDepartment = new DDepartment();
        }

        #region CREATE
        public Department Create(int createdBy, Department department)
        {
  
            EDepartment eDepartment = EDepartment(department);
            eDepartment.CreatedDate = DateTime.Now;
            eDepartment.CreatedBy = createdBy;
            eDepartment = _iDDepartment.Create(eDepartment);
            return (Department(eDepartment));
        }

        #endregion

        #region READ
        public Department Read(int departmentId)
        {
            EDepartment eDepartment = _iDDepartment.Read<EDepartment>(a => a.DepartmentId == departmentId);
            return Department(eDepartment);
        }

        public List<Department> Read()
        {
            List<EDepartment> eDepartments = _iDDepartment.List<EDepartment>(a => true);
            return Departments(eDepartments);
        }

        public List<Department> Read(int employeeId, string sortBy)
        {
            List<EDepartment> eDepartments = _iDDepartment.Read<EDepartment>(a => a.EmployeeDepartments.Any(b => b.EmployeeId == employeeId), sortBy);
            return Departments(eDepartments);
        }
        #endregion

        #region UPDATE
        public Department Update(int updatedBy, Department department)
        {
            var eDepartment = _iDDepartment.Update(EDepartment(department));
            eDepartment.UpdatedDate = DateTime.Now;
            eDepartment.UpdatedBy = updatedBy;
            return (Department(eDepartment));
        }
        #endregion

        #region DELETE
        public void Delete(int departmentId)
        {
            _iDDepartment.Delete<EDepartment>(a => a.DepartmentId == departmentId);
        }
        #endregion

        private List<Department> Departments(List<EDepartment> eDepartments)
        {
            return eDepartments.Select(a => new Department
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                DepartmentId = a.DepartmentId,
                UpdatedBy = a.UpdatedBy,

                Name = a.Name
            }).ToList();
        }

        private EDepartment EDepartment(Department department)
        {
            return new EDepartment
            {
                CreatedDate = department.CreatedDate,
                UpdatedDate = department.UpdatedDate,

                CreatedBy = department.CreatedBy,
                DepartmentId = department.DepartmentId,
                UpdatedBy = department.UpdatedBy,

                Name = department.Name
            };
        }

        private Department Department(EDepartment eDepartment)
        {
            return new Department
            {
                CreatedDate = eDepartment.CreatedDate,
                UpdatedDate = eDepartment.UpdatedDate,

                CreatedBy = eDepartment.CreatedBy,
                DepartmentId = eDepartment.DepartmentId,
                UpdatedBy = eDepartment.UpdatedBy,

                Name = eDepartment.Name
            };
        }
    }
}
