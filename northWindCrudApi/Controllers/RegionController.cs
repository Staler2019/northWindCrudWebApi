using Microsoft.AspNetCore.Mvc;
using northWindCrudApi.Business.DTOs;
using northWindCrudApi.Business.IServices;
using northWindCrudApi.Business.Validations;

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

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteRegion([NonZero]int id)
    {
        return Ok(await service.DeleteRegion(id));
    }

    [HttpPut]
    [Route("Description")]
    public async Task<IActionResult> UpdateRegionDescription(UpdateRegionDescriptionRequestDto request)
    {
        return Ok(await service.UpdateRegionDescription(request));
    }

    [HttpPost]
    public async Task<IActionResult> CreateRegion(CreateRegionRequestDto request)
    {
        return Ok(await service.CreateRegion(request));
    }
}
