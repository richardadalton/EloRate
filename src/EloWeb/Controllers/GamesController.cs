using System.Web.Mvc;
using EloClient.Models;
using EloClient.Repositories;

namespace EloWeb.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            ViewData.Model = RatingsRepo.Games();
            return View();
        }

        // GET: Games/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        public ActionResult Create(Game game)
        {
            RatingsRepo.AddGame(game);
            return Redirect("/Games");
        }

    }
}