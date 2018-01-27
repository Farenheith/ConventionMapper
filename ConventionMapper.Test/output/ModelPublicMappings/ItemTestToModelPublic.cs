using ConventionMapper;
using ConventionMapper.Test.Models;
using ConventionMapper.Test.Mirrors;
using System.Collections.Generic;

namespace ModelPublicMappings
{
  public partial class ItemTestToModelPublic : MappingBase, IMapping<ItemTest, ItemTestMirror>
  {
    public ItemTestToModelPublic(IConversionCache _cache) : base(_cache) { }
    public ItemTestToModelPublic() : base() { }

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
