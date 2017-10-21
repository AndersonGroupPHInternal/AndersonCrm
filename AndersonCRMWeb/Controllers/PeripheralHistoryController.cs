using AndersonCRMFunction;
using AndersonCRMModel;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace AndersonCRMWeb.Controllers
{
    [RoutePrefix("PeripheralHistory")]
    public class PeripheralHistoryController : Controller
    {
        private IFPeripheralHistory _iFPeripheralHistory;


        public PeripheralHistoryController()
        {
            _iFPeripheralHistory = new FPeripheralHistory();
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var peripheralhistory = _iFPeripheralHistory.Read(id);
            return View(peripheralhistory);
        }


        [HttpPost]
        public ActionResult Details(PeripheralHistory peripheralhistory)
        {
            try
            {
                _iFPeripheralHistory.Update(peripheralhistory);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var peripheralhistory = _iFPeripheralHistory.Read(id);
            return View(peripheralhistory);
        }


        [HttpPost]
        public ActionResult Edit(PeripheralHistory peripheralhistory)
        {
            try
            {
                _iFPeripheralHistory.Update(peripheralhistory);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PeripheralHistory());
        }

        [HttpPost]
        public JsonResult Create(PeripheralHistory peripheralhistory)
        {
            try
            {
                peripheralhistory = _iFPeripheralHistory.Create(peripheralhistory);
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
                PeripheralHistory peripheralhistory = new PeripheralHistory();
                return Json(_iFPeripheralHistory.List());
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
                PeripheralHistory peripheralhistory = _iFPeripheralHistory.Read(id);
                return View(peripheralhistory);
            }
            catch (Exception ex)
            {
                return View(new PeripheralHistory());
            }
        }

        [HttpPost]
        public ActionResult Update(PeripheralHistory peripheralhistory)
        {
            try
            {
                peripheralhistory = _iFPeripheralHistory.Update(peripheralhistory);
                return Json("");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public ActionResult Delete(PeripheralHistory peripheralhistory)
        {
            try
            {
                _iFPeripheralHistory.Delete(peripheralhistory);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

    }
}