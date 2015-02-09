using System.Linq;
using System.Web.Mvc;
using EloWeb.Models;
using EloWeb.Persist;

namespace EloWeb.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            var leaderboard = Players.All().OrderByDescending(p => p.Rating);
            if (!leaderboard.Any())
                return Redirect("/Players/NewLeague");

            ViewData.Model = Games.MostRecent(20, Games.GamesSortOrder.MostRecentFirst);
            return View();
        }

        // GET: Games/Create
        [HttpGet]
        public ActionResult Create()
        {
            var createGameView = new ViewModels.CreateGame
            {
                Players = Players.Active().Select(p=>p.Name).OrderBy(n=>n), 
                RecentGames = Games.MostRecent(5, Games.GamesSortOrder.MostRecentFirst)
            };
            ViewData.Model = createGameView;
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        public ActionResult Create(Game game)
        {
            if (game.Winner != game.Loser)
            {
                AzureGamesData.PersistGame(game);
                Games.Add(game);
                Players.UpdateRatings(game);
            }

            return Redirect("/");
        }

    }
}