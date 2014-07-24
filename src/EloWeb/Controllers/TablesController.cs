using System.Linq;
using System.Web.Mvc;
using EloWeb.Models;

namespace EloWeb.Controllers
{
    public class TablesController : Controller
    {
        // GET: Tables
        public ActionResult Rating()
        {
            var table = Players.All().OrderByDescending(p => p.Rating);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }

        public ActionResult GamesPlayed()
        {
            var table = Players.All().OrderByDescending(p => p.GamesPlayed);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }

        public ActionResult MaxRating()
        {
            var table = Players.All().OrderByDescending(p => p.MaxRating);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }

        public ActionResult WinRate()
        {
            var table = Players.All().OrderByDescending(p => p.WinRate);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }

        public ActionResult WinningStreak()
        {
            var table = Players.All().OrderByDescending(p => p.CurrentWinningStreak);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }

        public ActionResult BestEverWinningStreak()
        {
            var table = Players.All().OrderByDescending(p => p.LongestWinningStreak);
            if (!table.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = table;
            return View();
        }
    }
}