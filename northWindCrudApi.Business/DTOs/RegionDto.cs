using northWindCrudApi.Business.Validations;

namespace northWindCrudApi.Business.DTOs;

public class RegionDto
{
    public int RegionId { get; set; }
    public string RegionDescription { get; set; }
}

public class UpdateRegionDescriptionRequestDto
{
    [NonZero]
    public int RegionId { get; set; }
    [NonEmpty]
    public string RegionDescription { get; set; }
}

public class CreateRegionRequestDto
{
    [NonZero]
    public int RegionId { get; set; }
    [NonEmpty]
    public string RegionDescription { get; set; }
}
