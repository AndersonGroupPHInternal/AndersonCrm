using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AndersonCRMFunction
{
    public class FEmployeeNumber : IFEmployee
    {
        private IDEmployee _iDEmployee;

        public FEmployeeNumber()
        {
            _iDEmployee = new DEmployee();
        }

        #region CREATE
        public Employee Create(int createdBy, Employee employee)
        {
            EEmployee eEmployee = EEmployee(employee);
            eEmployee.CreatedDate = DateTime.Now;
            eEmployee.CreatedBy = createdBy;
            eEmployee = _iDEmployee.Create(eEmployee);
            return (Employee(eEmployee));
        }
        #endregion

        #region READ
        public Employee Read(int employeeId)
        {
            EEmployee eEmployee = _iDEmployee.Read<EEmployee>(a => a.EmployeeId == employeeId);
            return Employee(eEmployee);
        }

        public List<Employee> Read()
        {
            List<EEmployee> eEmployees = _iDEmployee.List<EEmployee>(a => true);
            return Employees(eEmployees);
        }

        public List<Employee> Read(int companyId, string sortBy)
        {
            List<EEmployee> eEmployees = _iDEmployee.Read<EEmployee>(a => a.CompanyId == companyId, sortBy);
            return Employees(eEmployees);
        }

        public List<Employee> ReadAndersonPhEmployees()
        {
            List<EEmployee> eEmployees = _iDEmployee.Read<EEmployee>(a => a.Company.Name == "AndersonGroupPH", "LastName");
            return Employees(eEmployees);
        }

        public List<Employee> ReadAssetHistory(int assetId, string sortBy)
        {
            List<EEmployee> eEmployees = _iDEmployee.Read<EEmployee>(a => a.AssetHistories.Any(b => b.AssetId == assetId), sortBy);
            return Employees(eEmployees);
        }

        #endregion

        #region UPDATE
        public Employee Update(int updatedBy, Employee employee)
        {
            EEmployee eEmployee = EEmployee(employee);
            eEmployee.UpdatedDate = DateTime.Now;
            eEmployee.UpdatedBy = updatedBy;
            eEmployee = _iDEmployee.Update(EEmployee(employee));
            return (Employee(eEmployee));
        }
        #endregion

        #region DELETE
        public void Delete(int employeeId)
        {
            _iDEmployee.Delete<EEmployee>(a => a.EmployeeId == employeeId);
        }
        #endregion

        private List<Employee> Employees(List<EEmployee> eEmployees)
        {
            return eEmployees.Select(a => new Employee
            {
                CreatedDate = a.CreatedDate,
                DateHired = a.DateHired,
                DateStarted = a.DateStarted,
                DateEnded = a.DateEnded,
                UpdatedDate = a.UpdatedDate,

                EmployeeNumber = a.EmployeeNumber,
                CompanyId = a.CompanyId,
                CreatedBy = a.CreatedBy,
                EmployeeId = a.EmployeeId,
                JobTitleId = a.JobTitleId,
                ManagerEmployeeId = a.ManagerEmployeeId,
                UpdatedBy = a.UpdatedBy,

                Email = a.Email,
                FirstName = a.FirstName,
                LastName = a.LastName,
                MiddleName = a.MiddleName
            }).ToList();
        }

        private EEmployee EEmployee(Employee employee)
        {
            return new EEmployee
            {
                CreatedDate = employee.CreatedDate,
                DateHired = employee.DateHired,
                DateStarted = employee.DateStarted,
                DateEnded = employee.DateEnded,
                UpdatedDate = employee.UpdatedDate,

                EmployeeNumber = employee.EmployeeNumber,
                CompanyId = employee.CompanyId,
                CreatedBy = employee.CreatedBy,
                EmployeeId = employee.EmployeeId,
                JobTitleId = employee.JobTitleId,
                ManagerEmployeeId = employee.ManagerEmployeeId,
                UpdatedBy = employee.UpdatedBy,

                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName
            };
        }

        private Employee Employee(EEmployee eEmployee)
        {
            Employee returnEmployee = new Employee
            {
                CreatedDate = eEmployee.CreatedDate,
                DateHired = eEmployee.DateHired,
                DateStarted = eEmployee.DateStarted,
                DateEnded = eEmployee.DateEnded,
                UpdatedDate = eEmployee.UpdatedDate,

                EmployeeNumber = eEmployee.EmployeeNumber,
                CompanyId = eEmployee.CompanyId,
                CreatedBy = eEmployee.CreatedBy,
                EmployeeId = eEmployee.EmployeeId,
                JobTitleId = eEmployee.JobTitleId,
                ManagerEmployeeId = eEmployee.ManagerEmployeeId,
                UpdatedBy = eEmployee.UpdatedBy,

                Email = eEmployee.Email,
                FirstName = eEmployee.FirstName,
                LastName = eEmployee.LastName,
                MiddleName = eEmployee.MiddleName
            };
            return returnEmployee;
        }
    }
}
