using AndersonCRMModel;
using AndersonCRMFunction;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    public class DepartmentController : BaseController
    {
        private IFDepartment _iFDepartment;
        public DepartmentController(IFDepartment iFDepartment)
        {
            _iFDepartment = iFDepartment;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Department());
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            var createdDepartment = _iFDepartment.Create(UserId, department);
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
            return Json(_iFDepartment.Read());
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFDepartment.Read(id));
        }

        [HttpPost]
        public ActionResult Update(Department department)
        {
            var createdDepartment = _iFDepartment.Update(UserId, department);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFDepartment.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}