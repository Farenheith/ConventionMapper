using ConventionMapper;
using ConventionMapper.Test.Models.Base;
using ConventionMapper.Test.Mirrors.Base;
using System.Collections.Generic;

namespace ModelPublicMappings
{
  public partial class BaseTestToModelPublic : MappingBase, IMapping<BaseTest, BaseTestMirror>
  {
    public BaseTestToModelPublic(IConversionCache _cache) : base(_cache) { }
    public BaseTestToModelPublic() : base() { }

    public BaseTestMirror Convert(BaseTest source, BaseTestMirror destination)
    {
			      destination.Id = source.Id;
			      return TreatResult(destination);
    }

	public BaseTestMirror Map(BaseTest source)
	{
		return Map<BaseTest, BaseTestMirror>(source);
	}
  }
}
