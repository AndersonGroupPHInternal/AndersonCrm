using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;

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
        public Department Create(Department department)
        {
  
            EDepartment eDepartment = EDepartment(department);
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

        public List<Department> List()
        {
            List<EDepartment> eDepartments = _iDDepartment.List<EDepartment>(a => true);
            return Departments(eDepartments);
        }

        public Department Read(string description)
        {
            EDepartment eDepartment = _iDDepartment.Read<EDepartment>(a => a.Description == description);
            return Department(eDepartment);
        }
        #endregion

        #region UPDATE
        public Department Update(Department department)
        {
            var eDepartment = _iDDepartment.Update(EDepartment(department));
            return (Department(eDepartment));
        }
        #endregion

        #region DELETE
        public void Delete(Department department)
        {
            _iDDepartment.Delete(EDepartment(department));
        }
        #endregion

        private List<Department> Departments(List<EDepartment> eDepartments)
        {
            var returnDepartments = eDepartments.Select(a => new Department
            {
                DepartmentId = a.DepartmentId,

                Description = a.Description,
                DepartmentColor = a.DepartmentColor,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy
            });

            return returnDepartments.ToList();
        }
        private EDepartment EDepartment(Department department)
        {
            EDepartment returnEDepartment = new EDepartment
            {
                DepartmentId = department.DepartmentId,

                Description = department.Description,
                DepartmentColor = department.DepartmentColor,
                CreatedBy = department.CreatedBy,
                UpdatedBy = department.UpdatedBy
            };
            return returnEDepartment;
        }

        private Department Department(EDepartment eDepartment)
        {
            Department returnDepartment = new Department
            {
                DepartmentId = eDepartment.DepartmentId,

                Description = eDepartment.Description,
                DepartmentColor = eDepartment.DepartmentColor,
                CreatedBy = eDepartment.CreatedBy,
                UpdatedBy = eDepartment.UpdatedBy
            };
            return returnDepartment;
        }
    }
}
