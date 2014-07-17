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
            ViewData.Model = Games.MostRecent(20);
            return View();
        }

        // GET: Games/Create
        [HttpGet]
        public ActionResult Create()
        {
            var createGameView = new ViewModels.CreateGame
            {
                Players = Players.Names().OrderBy(p=>p), 
                RecentGames = Games.MostRecent(5)
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
                Games.Add(game);                
                Players.UpdateRatings(game);
                GamesData.PersistGame(game.ToString());                
            }

            return Redirect("/Games");
        }

    }
}