using System.Web.Mvc;
using EloWeb.Repositories;

namespace EloWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData.Model = RatingsRepo.Leaderboard();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}