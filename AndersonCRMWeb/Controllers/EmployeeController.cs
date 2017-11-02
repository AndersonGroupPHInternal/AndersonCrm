using AndersonCRMModel;
using AndersonCRMFunction;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    public class EmployeeController : BaseController
    {
        private IFEmployee _iFEmployee;
        public EmployeeController(IFEmployee iFEmployee)
        {
            _iFEmployee = iFEmployee;
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