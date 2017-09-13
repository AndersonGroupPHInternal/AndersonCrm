using AndersonCRMModel;
using AndersonCRMData;
using AndersonCRMEntity;
using System.Collections.Generic;
using System.Linq;

namespace AndersonCRMFunction
{
    public class FEmployee : IFEmployee
    {
        private IDEmployee _iDEmployee;

        public FEmployee()
        {
            _iDEmployee = new DEmployee();
        }

        #region CREATE
        public Employee Create(Employee employee)
        {
            EEmployee eEmployee = EEmployee(employee);
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
        //Master Edit this
        public List<Employee> List()
        {
            List<EEmployee> eEmployees = _iDEmployee.Read();
            return Employees(eEmployees);
        }

        public List<Employee> List(int companyId)
        {
            List<EEmployee> eEmployees = _iDEmployee.List<EEmployee>(a => a.CompanyId == companyId);
            return Employees(eEmployees);

        }
        #endregion

        #region UPDATE
        public Employee Update(Employee employee)
        {
            var eEmployee = _iDEmployee.Update(EEmployee(employee));
            return (Employee(eEmployee));
        }
        #endregion

        #region DELETE
        public void Delete(Employee employee)
        {
            _iDEmployee.Delete(EEmployee(employee));
        }
        #endregion
        private List<Employee> Employees(List<EEmployee> eEmployees)
        {
            var returnEmployees = eEmployees.Select(a => new Employee
            {
                EmployeeId = a.EmployeeId,
                CompanyId = a.CompanyId,
                PositionId = a.PositionId,

                EmployeeNumber = a.EmployeeNumber,
                Department = a.Department,
                Email = a.Email,
                FirstName = a.FirstName,
                LastName = a.LastName,
                MiddleName = a.MiddleName,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy,
                Position = new Position
                {
                    PositionName = a.Position.PositionName
                },
                Company = new Company
                {
                    CompanyName = a.Company.CompanyName
                }
            });

            return returnEmployees.ToList();
        }

        private EEmployee EEmployee(Employee employee)
        {
            EEmployee returnEEmployee = new EEmployee
            {
                EmployeeId = employee.EmployeeId,
                CompanyId = employee.CompanyId,
                PositionId = employee.PositionId,
                
                EmployeeNumber = employee.EmployeeNumber,
                Department=employee.Department,
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                CreatedBy = employee.CreatedBy,
                UpdatedBy = employee.UpdatedBy
            };
            return returnEEmployee;
        }

        private Employee Employee(EEmployee eEmployee)
        {
            Employee returnEmployee = new Employee
            {
                EmployeeId = eEmployee.EmployeeId,
                CompanyId = eEmployee.CompanyId,
                PositionId = eEmployee.PositionId,
          
                EmployeeNumber = eEmployee.EmployeeNumber,
                Email = eEmployee.Email,
                Department=eEmployee.Department,
                FirstName = eEmployee.FirstName,
                LastName = eEmployee.LastName,
                MiddleName = eEmployee.MiddleName,

                CreatedBy = eEmployee.CreatedBy,
                UpdatedBy = eEmployee.UpdatedBy
            };
            return returnEmployee;
        }
    }
}
