using AndersonCRMModel;
using AndersonCRMFunction;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    public class AssetController : BaseController
    {
        private IFAsset _iFAsset;
        public AssetController(IFAsset iFAsset)
        {
            _iFAsset = iFAsset;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Asset());
        }

        [HttpPost]
        public ActionResult Create(Asset asset)
        {
            var createdAsset = _iFAsset.Create(UserId, asset);
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
            return Json(_iFAsset.Read());
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFAsset.Read(id));
        }

        [HttpPost]
        public ActionResult Update(Asset asset)
        {
            var createdAsset = _iFAsset.Update(UserId, asset);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFAsset.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}