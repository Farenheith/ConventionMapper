using ConventionMapper;
using ConventionMapper.Test.Mirrors;
using ConventionMapper.Test.Models;
using System.Collections.Generic;

namespace MirrorMappings
{
  internal partial class ItemTestMirrorToMirror : MappingBase, IMapping<ItemTestMirror, ItemTest>
  {
    public ItemTestMirrorToMirror(IConversionCache _cache) : base(_cache) { }
    public ItemTestMirrorToMirror() : base() { }

    public ItemTest Convert(ItemTestMirror source, ItemTest destination)
    {
			      destination.Header = Get<HeaderTest>(source.Header);
			      destination.StringField = source.StringField;
			      destination.Id = source.Id;
			      return TreatResult(destination);
    }

	public ItemTest Map(ItemTestMirror source)
	{
		return Map<ItemTestMirror, ItemTest>(source);
	}
  }
}
