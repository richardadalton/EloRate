using System.Linq;
using System.Web.Mvc;
using EloWeb.Models;

namespace EloWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData.Model = Players.All().OrderByDescending(p => p.Rating);            
            return View();
        }
    }
}