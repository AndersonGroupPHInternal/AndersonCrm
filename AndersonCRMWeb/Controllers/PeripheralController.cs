//using AndersonCRMFunction;
//using AndersonCRMModel;
//using System;
//using System.Web.Mvc;
//using System.Web.Routing;


//namespace AndersonCRMWeb.Controllers
//{
//    [RoutePrefix("Peripheral")]
//    public class PeripheralController : Controller
//    {
//        private IFPeripheral _iFPeripheral;


//        public PeripheralController()
//        {
//            _iFPeripheral = new FPeripheral();

//        }

//        [Route("")]
//        [HttpGet]
//        public ActionResult Index()
//        {
//            return View();
//        }
//        [HttpGet]
//        public ActionResult Edit(int id)
//        {
//            var peripheral = _iFPeripheral.Read(id);
//            return View(peripheral);
//        }
//        [HttpGet]
//        public ActionResult Details(int id)
//        {
//            var peripheral = _iFPeripheral.Read(id);
//            return View(peripheral);
//        }
//        [HttpGet]
//        public ActionResult Create()
//        {
//            return View(new Peripheral());
//        }
//        [HttpGet]
//        public ActionResult Add()
//        {
//            Peripheral peripheral = new Peripheral();
//            //peripheral.Date = DateTime.Now.ToString("MMMM dd, yyyy");
//            return View(peripheral);
//        }

//        [HttpPost]
//        public JsonResult Create(Peripheral peripheral)
//        {
//            try
//            {
//                //peripheral = _iFPeripheral.Create(peripheral);
//                return Json("");
//            }
//            catch (Exception ex)
//            {
//                return Json(ex);
//            }

//        }
//        [HttpPost]
//        public ActionResult Edit(Peripheral peripheral)
//        {
//            try
//            {
//                //_iFPeripheral.Update(peripheral);
//                return RedirectToAction("Index");
//            }
//            catch (Exception ex)
//            {
//                return View();
//            }
//        }
//        [HttpPost]
//        public ActionResult Details(Peripheral peripheral)
//        {
//            try
//            {
//                //_iFPeripheral.Update(peripheral);
//                return RedirectToAction("Index");
//            }
//            catch (Exception ex)
//            {
//                return View();
//            }
//        }

//        [Route("List")]
//        [HttpPost]
//        public ActionResult List()
//        {
//            try
//            {
//                Peripheral peripheral = new Peripheral();
//                return Json(_iFPeripheral.Read());
//            }
//            catch (Exception exception)
//            {
//                return Json(exception);
//            }
//        }

//        [HttpGet]
//        public ActionResult Update(int id)
//        {
//            try
//            {
//                Peripheral peripheral = _iFPeripheral.Read(id);
//                return View(peripheral);
//            }
//            catch (Exception ex)
//            {
//                return View(new Peripheral());
//            }
//        }

//        [HttpPost]
//        public ActionResult Update(Peripheral peripheral)
//        {
//            try
//            {
//                //peripheral = _iFPeripheral.Update(peripheral);

//                return Json("");
//            }
//            catch (Exception ex)
//            {
//                return View(ex);
//            }
//        }

//        [HttpPost]
//        public ActionResult Delete(Peripheral peripheral)
//        {
//            try
//            {
//                //_iFPeripheral.Delete(peripheral);
//                return Json("");
//            }
//            catch (Exception ex)
//            {
//                return Json(ex);
//            }
//        }


//    }
//}

using AndersonCRMModel;
using AndersonCRMFunction;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    public class PeripheralController : BaseController
    {
        private IFPeripheral _iFPeripheral;
        public PeripheralController(IFPeripheral iFPeripheral)
        {
            _iFPeripheral = iFPeripheral;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Peripheral());
        }

        [HttpPost]
        public ActionResult Create(Peripheral peripheral)
        {
            var createdPeripheral = _iFPeripheral.Create(UserId, peripheral);
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
            return Json(_iFPeripheral.Read());
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFPeripheral.Read(id));
        }

        [HttpPost]
        public ActionResult Update(Peripheral peripheral)
        {
            var createdPeripheral = _iFPeripheral.Update(UserId, peripheral);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFPeripheral.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}