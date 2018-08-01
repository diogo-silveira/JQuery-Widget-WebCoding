
using Microsoft.AspNetCore.Mvc;

namespace HotelsCombined.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/default.htm");
        }
    }

}