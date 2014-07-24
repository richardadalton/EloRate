using System.Linq;
using System.Web.Mvc;
using EloWeb.Models;

namespace EloWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var leaderboard = Players.All().OrderByDescending(p => p.Rating);
            if (!leaderboard.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = leaderboard;
            return View();
        }
    }
}