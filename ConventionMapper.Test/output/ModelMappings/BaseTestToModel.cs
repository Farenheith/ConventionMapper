using ConventionMapper;
using ConventionMapper.Test.Models.Base;
using ConventionMapper.Test.Mirrors.Base;
using System.Collections.Generic;

namespace ModelMappings
{
  internal partial class BaseTestToModel : MappingBase, IMapping<BaseTest, BaseTestMirror>
  {
    public BaseTestToModel(IConversionCache _cache) : base(_cache) { }
    public BaseTestToModel() : base() { }

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
