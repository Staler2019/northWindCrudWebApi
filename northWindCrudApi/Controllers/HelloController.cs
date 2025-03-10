using Microsoft.AspNetCore.Mvc;
using northWindCrudApi.Business.IServices;
using northWindCrudApi.Business.Validations;

namespace northWindCrudApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController(IHelloService service) : ControllerBase
{
    [HttpGet]
    public ActionResult<string> SayHello([NonEmpty] string name)
    {
        return Ok(service.SayHello(name));
    }
}
