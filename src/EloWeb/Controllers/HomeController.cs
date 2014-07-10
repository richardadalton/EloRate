using System.Linq;
using System.Web.Mvc;
using EloWeb.Repositories;

namespace EloWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData.Model = RatingsRepo.Players()
                                        .Values
                                        .OrderByDescending(p => p.Rating);
            
            return View();
        }
    }
}