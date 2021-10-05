using Microsoft.AspNetCore.Mvc;

namespace Contacts.HttpApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
