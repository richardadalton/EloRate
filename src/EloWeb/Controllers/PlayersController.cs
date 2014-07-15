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
            var players = Players.All();
            ViewData.Model = players.OrderBy(p => p.Name);

            return View();
        }

        // GET: Players/Details?name=......
        public ActionResult Details(string name)
        {
            var playerDetails = new ViewModels.PlayerDetails(Players.PlayerByName(name), Games.All());
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
            return Redirect("/Players");
        }
    }
}