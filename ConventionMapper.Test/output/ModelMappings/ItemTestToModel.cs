using ConventionMapper;
using ConventionMapper.Test.Models;
using ConventionMapper.Test.Mirrors;
using System.Collections.Generic;

namespace ModelMappings
{
  internal partial class ItemTestToModel : MappingBase, IMapping<ItemTest, ItemTestMirror>
  {
    public ItemTestToModel(IConversionCache _cache) : base(_cache) { }
    public ItemTestToModel() : base() { }

    public ItemTestMirror Convert(ItemTest source, ItemTestMirror destination)
    {
			      destination.Header = Get<HeaderTestMirror>(source.Header);
			      destination.StringField = source.StringField;
			      destination.Id = source.Id;
			      return TreatResult(destination);
    }

	public ItemTestMirror Map(ItemTest source)
	{
		return Map<ItemTest, ItemTestMirror>(source);
	}
  }
}
