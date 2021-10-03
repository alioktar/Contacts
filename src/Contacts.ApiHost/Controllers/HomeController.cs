using Microsoft.AspNetCore.Mvc;

namespace Contacts.ApiHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Redirect("swagger/index.html");
        }
    }
}
