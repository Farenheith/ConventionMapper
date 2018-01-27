using ConventionMapper.Test.Models.Base;
using System.Collections.Generic;

namespace ConventionMapper.Test.Models
{
    public class HeaderTest : BaseTest
    {
        public string StringField { get; set; }
        public virtual ICollection<ItemTest> Items { get; set; }
    }
}
