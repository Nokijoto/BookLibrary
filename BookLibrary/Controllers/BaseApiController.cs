using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{


    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseApiController : ControllerBase
    {

    }
}
