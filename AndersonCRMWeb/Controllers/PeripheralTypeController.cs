using AndersonCRMModel;
using AndersonCRMFunction;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    public class PeripheralTypeController : BaseController
    {
        private IFPeripheralType _iFPeripheralType;
        public PeripheralTypeController(IFPeripheralType iFPeripheralType)
        {
            _iFPeripheralType = iFPeripheralType;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new PeripheralType());
        }

        [HttpPost]
        public ActionResult Create(PeripheralType peripheralType)
        {
            var createdPeripheralType = _iFPeripheralType.Create(UserId, peripheralType);
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
            return Json(_iFPeripheralType.Read());
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFPeripheralType.Read(id));
        }

        [HttpPost]
        public ActionResult Update(PeripheralType peripheralType)
        {
            var createdPeripheralType = _iFPeripheralType.Update(UserId, peripheralType);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFPeripheralType.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}