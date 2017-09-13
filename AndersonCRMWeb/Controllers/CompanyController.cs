using AndersonCRMModel;
using AndersonCRMFunction;
//using System.Data;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Net;
using System.Data.Entity;
//using System.Net;
//using System.Collections.Generic;

namespace AndersonCRMWeb.Controllers
{
    [RoutePrefix("Company")]
    public class CompanyController : Controller
    {


        private IFCompany _iFCompany;


        //public object db { get; private set; }

        public CompanyController()
        {
            _iFCompany = new FCompany();
           
        }
        


        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var company = _iFCompany.Read(id);
            return View(company);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
    

        //[HttpGet]
        //public ActionResult Create()
        //{
           
        //        //ViewBag.CompanyId = new SelectList(db.Company, "GenderId", "Description");
              
        //    return View(new Company());
        //}

        //[HttpGet]
        //public ActionResult Details()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Details(int id)
        {
            var company = _iFCompany.Read(id);
            return View(company);
        }


        [HttpPost]
        public ActionResult Details(Company company)
        {
            try
            {
                _iFCompany.Update(company);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Create(Company company)
        {
            //company = _iFCompany.Create(company);
            //return View(company);
            try
            {
                company = _iFCompany.Create(company);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


      
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "Company/Index/CompanyId",
                defaults: new
                {
                    controller = "Company",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }


        [HttpPost]
        public ActionResult Edit(Company company)
        {
            try
            {
                _iFCompany.Update(company);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }



        [Route("List")]
        [HttpPost]
        public ActionResult List()
        {
            try
            {
                Company company = new Company();
                return Json(_iFCompany.List());
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
                Company company = _iFCompany.Read(id);
                return View(company);
            }
            catch (Exception ex)
            {
                return View(new Company());
            }
        }

        [HttpPost]
        public ActionResult Update(Company company)
        {
            try
            {
                company = _iFCompany.Update(company);
                return Json("");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public ActionResult Delete(Company company)
        {
            try
            {
                _iFCompany.Delete(company);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}