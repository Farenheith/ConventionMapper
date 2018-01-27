
using ConventionMapper;
using ConventionMapper.Test.Mirrors;
using ConventionMapper.Test.Models;
using System.Collections.Generic;

namespace MirrorMappings
{
  internal partial class HeaderTestMirrorToMirror : MappingBase, IMapping<HeaderTestMirror, HeaderTest>
  {
    public HeaderTestMirrorToMirror(IConversionCache _cache) : base(_cache) { }
    public HeaderTestMirrorToMirror() : base() { }

    public HeaderTest Convert(HeaderTestMirror source, HeaderTest destination)
    {
			      destination.StringField = source.StringField;
			      destination.Items = Get<ItemTest>(source.Items);
			      destination.Id = source.Id;
			      return TreatResult(destination);
    }

	public HeaderTest Map(HeaderTestMirror source)
	{
		return Map<HeaderTestMirror, HeaderTest>(source);
	}
  }
}
