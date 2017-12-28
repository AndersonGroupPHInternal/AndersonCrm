using AndersonCRMModel;
using AndersonCRMFunction;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    public class AssetTypeController : BaseController
    {
        private IFAssetType _iFAssetType;
        public AssetTypeController(IFAssetType iFAssetType)
        {
            _iFAssetType = iFAssetType;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new AssetType());
        }

        [HttpPost]
        public ActionResult Create(AssetType assetType)
        {
            var createdAssetType = _iFAssetType.Create(UserId, assetType);
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
            return Json(_iFAssetType.Read());
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFAssetType.Read(id));
        }

        [HttpPost]
        public ActionResult Update(AssetType assetType)
        {
            var createdAssetType = _iFAssetType.Update(UserId, assetType);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFAssetType.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}