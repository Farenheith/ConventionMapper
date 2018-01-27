using ConventionMapper;
using ConventionMapper.Test.Mirrors.Base;
using ConventionMapper.Test.Models.Base;
using System.Collections.Generic;

namespace MirrorMappings
{
  internal partial class BaseTestMirrorToMirror : MappingBase, IMapping<BaseTestMirror, BaseTest>
  {
    public BaseTestMirrorToMirror(IConversionCache _cache) : base(_cache) { }
    public BaseTestMirrorToMirror() : base() { }

    public BaseTest Convert(BaseTestMirror source, BaseTest destination)
    {
			      destination.Id = source.Id;
			      return TreatResult(destination);
    }

	public BaseTest Map(BaseTestMirror source)
	{
		return Map<BaseTestMirror, BaseTest>(source);
	}
  }
}
