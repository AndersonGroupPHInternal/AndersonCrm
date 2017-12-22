using AndersonCRMModel;
using AndersonCRMFunction;
using System.Web.Mvc;
using System.Configuration;
using System.IO;
using System.Web;
using System.Linq;

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
            //AddEmployeeImage(employee, UserId, );
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
            string folder = ConfigurationManager.AppSettings["ImageFolder"];
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


        #region AddEmployeeImage
        [HttpPost]
        public ActionResult AddEmployeeImage(Employee employeeimage, int employeeID, HttpPostedFileBase file)
        {
            var id = employeeimage.EmployeeNumber;
            var Image = id + Path.GetExtension(file.FileName);
            Image = Image.Split('\\').Last(); //This will fix problems when uploading using IE
            var path = Path.Combine(Server.MapPath("~/Content/Images/") + id);
            file.SaveAs(path);
            employeeimage.Url = Image;
            throw new System.Exception();

            // _iFEmployee.Create(employeeimage);
            //return Json(string.Empty);
        }
        #endregion





    }
}