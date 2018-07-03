using AndersonCRMModel;
using AndersonCRMFunction;
using System.Web.Mvc;
using System.Linq;
using System;

namespace AndersonCRMWeb.Controllers
{
    public class EmployeeController : BaseController
    {
        private IFEmployee _iFEmployee;
        private IFEmployeeTeam _iFEmployeeTeam;
        private IFEmployeeDepartment _iFEmployeeDepartment;
        public EmployeeController(IFEmployee iFEmployee, IFEmployeeTeam iFEmployeeTeam, IFEmployeeDepartment iFEmployeeDepartment)
        {
            _iFEmployee = iFEmployee;
            _iFEmployeeTeam = iFEmployeeTeam;
            _iFEmployeeDepartment = iFEmployeeDepartment;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Employee());
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            var createdEmployee = _iFEmployee.Create(UserId, employee);
            return RedirectToAction("Index");
        }
        #endregion

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFEmployee.Read());
        }

        [HttpPost]
        public JsonResult ReadFiltered(EmployeeFilter employeeFilter)
        {
            try
            {
                return Json(_iFEmployee.Read(employeeFilter));
            }
            catch (Exception exception)
            {
                return Json(exception);
            }
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFEmployee.Read(id));
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            _iFEmployeeTeam.Create(UserId, employee.EmployeeId, employee.EmployeeTeams);
            _iFEmployeeDepartment.Create(UserId, employee.EmployeeId, employee.EmployeeDepartments);
            var createdEmployee = _iFEmployee.Update(UserId, employee);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]

        public JsonResult Delete(int id)
        {
            _iFEmployee.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}