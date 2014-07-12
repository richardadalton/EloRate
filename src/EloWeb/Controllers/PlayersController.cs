using System.Linq;
using System.Web.Mvc;
using EloWeb.Models;
using EloWeb.Repositories;

namespace EloWeb.Controllers
{
    public class PlayersController : Controller
    {
        // GET: Players
        public ActionResult Index()
        {
            var players = RatingsRepo.Players().Values;
            ViewData.Model = players.OrderBy(p => p.Name);

            return View();
        }

        // GET: Players/Details?name=......
        public ActionResult Details(string name)
        {
            var playerDetails = new ViewModels.PlayerDetails(RatingsRepo.PlayerByName(name), RatingsRepo.Games());
            ViewData.Model = playerDetails;
            return View();
        }

        // GET: Players/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        public ActionResult Create(Player player)
        {
            RatingsRepo.AddPlayer(player.Name);
            return Redirect("/Players");
        }
    }
}