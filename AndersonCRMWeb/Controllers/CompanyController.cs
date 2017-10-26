using AndersonCRMModel;
using AndersonCRMFunction;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    public class CompanyController : BaseController
    {
        private IFCompany _iFCompany;
        public CompanyController(IFCompany iFCompany)
        {
            _iFCompany = iFCompany;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Company());
        }

        [HttpPost]
        public ActionResult Create(Company company)
        {
            var createdCompany = _iFCompany.Create(UserId, company);
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
            return Json(_iFCompany.Read());
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFCompany.Read(id));
        }

        [HttpPost]
        public ActionResult Update(Company company)
        {
            var createdCompany = _iFCompany.Update(UserId, company);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFCompany.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}