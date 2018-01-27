
using ConventionMapper;
using ConventionMapper.Test.Models;
using ConventionMapper.Test.Mirrors;
using System.Collections.Generic;

namespace ModelPublicMappings
{
  public partial class HeaderTestToModelPublic : MappingBase, IMapping<HeaderTest, HeaderTestMirror>
  {
    public HeaderTestToModelPublic(IConversionCache _cache) : base(_cache) { }
    public HeaderTestToModelPublic() : base() { }

    public HeaderTestMirror Convert(HeaderTest source, HeaderTestMirror destination)
    {
			      destination.StringField = source.StringField;
			      destination.Items = Get<ItemTestMirror>(source.Items);
			      destination.Id = source.Id;
			      return TreatResult(destination);
    }

	public HeaderTestMirror Map(HeaderTest source)
	{
		return Map<HeaderTest, HeaderTestMirror>(source);
	}
  }
}
