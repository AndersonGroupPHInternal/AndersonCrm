using AndersonCRMModel;
using AndersonCRMFunction;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    public class TeamController : BaseController
    {
        private IFTeam _iFTeam;
        public TeamController(IFTeam iFTeam)
        {
            _iFTeam = iFTeam;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Team());
        }

        [HttpPost]
        public ActionResult Create(Team team)
        {
            var createdTeam = _iFTeam.Create(UserId, team);
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
            return Json(_iFTeam.Read());
        }

        [HttpPost]
        public JsonResult ReadSelectedTeam(int id)
        {
            return Json(_iFTeam.Read(id, "TeamId"));
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFTeam.Read(id));
        }

        [HttpPost]
        public ActionResult Update(Team team)
        {
            var createdTeam = _iFTeam.Update(UserId, team);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFTeam.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}