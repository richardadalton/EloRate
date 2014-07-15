using System.Linq;
using System.Web.Mvc;
using EloWeb.Models;
using EloWeb.Persist;

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
            var player = Players.PlayerByName(name);
            ViewData.Model = player;
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
            Players.Add(Players.CreateInitial(player.Name)); 
            PlayersData.PersistPlayer(player.Name);         
            return Redirect("/Players");
        }
    }
}