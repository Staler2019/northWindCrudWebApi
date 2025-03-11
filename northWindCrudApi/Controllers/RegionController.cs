using Microsoft.AspNetCore.Mvc;
using northWindCrudApi.Business.IServices;

namespace northWindCrudApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionController(IRegionService service):ControllerBase
{
    [HttpGet]
    [Route("/Regions")]
    public async Task<IActionResult> GetRegions()
    {
        var regions = await service.GetRegions();

        return Ok(regions);
    }
}
