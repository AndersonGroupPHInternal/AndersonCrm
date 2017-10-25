using AndersonCRMFunction;
using AndersonCRMModel;
using System;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    [RoutePrefix("JobTitle")]
    public class JobTitleController : Controller
    {
        private IFJobTitle _iFJobTitle;

        public JobTitleController()
        {
            _iFJobTitle = new FJobTitle();
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
            return View(new JobTitle());
        }

        public ActionResult Edit(int id)
        {
            var jobTitle = _iFJobTitle.Read(id);
            return View(jobTitle);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var jobTitle = _iFJobTitle.Read(id);
            return View(jobTitle);
        }


        [HttpPost]
        public ActionResult Details(JobTitle jobTitle)
        {
            try
            {
                //_iFJobTitle.Update(jobTitle);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(JobTitle jobTitle)
        {
            try
            {
                //_iFJobTitle.Update(jobTitle);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Create(JobTitle jobTitle)
        {
            try
            {
                //jobTitle = _iFJobTitle.Create(jobTitle);
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
                JobTitle jobTitle = new JobTitle();
                return Json(_iFJobTitle.Read());
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
                JobTitle jobTitle = _iFJobTitle.Read(id);
                return View(jobTitle);
            }
            catch (Exception ex)
            {
                return View(new JobTitle());
            }
        }

        [HttpPost]
        public JsonResult Update(JobTitle jobTitle)
        {
            try
            {
                //jobTitle = _iFJobTitle.Update(jobTitle);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public ActionResult Delete(JobTitle jobTitle)
        {
            try
            {
                //_iFJobTitle.Delete(jobTitle);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}