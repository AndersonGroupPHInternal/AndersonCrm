using AndersonCRMFunction;
using AndersonCRMModel;
using System;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    [RoutePrefix("Department")]
    public class DepartmentController : Controller
    {
        private IFDepartment _iFDepartment;

        public DepartmentController()
        {
            _iFDepartment = new FDepartment();
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Department());
        }

        public ActionResult Edit(int id)
        {
            var department = _iFDepartment.Read(id);
            return View(department);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var department = _iFDepartment.Read(id);
            return View(department);
        }


        [HttpPost]
        public ActionResult Details(Department department)
        {
            try
            {
                //_iFDepartment.Update(department);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            try
            {
                //_iFDepartment.Update(department);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Create(Department department)
        {
            try
            {
                //department = _iFDepartment.Create(department);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [Route("List")]
        [HttpPost]
        public ActionResult List()
        {
            try
            {
                Department department = new Department();
                return Json(_iFDepartment.Read());
            }
            catch (Exception exception)
            {
                return Json(exception);
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                Department department = _iFDepartment.Read(id);
                return View(department);
            }
            catch (Exception ex)
            {
                return View(new Department());
            }
        }

        [HttpPost]
        public JsonResult Update(Department department)
        {
            try
            {
                //department = _iFDepartment.Update(department);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public ActionResult Delete(Department department)
        {
            try
            {
                //_iFDepartment.Delete(department);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}