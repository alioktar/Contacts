using Microsoft.AspNetCore.Mvc;

namespace Contacts.ApiHost.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("swagger/index.html");
        }
    }
}
