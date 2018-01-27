using ConventionMapper.Test.Mirrors.Base;
using System.Collections.Generic;

namespace ConventionMapper.Test.Mirrors
{
    public class HeaderTestMirror : BaseTestMirror
    {
        public string StringField { get; set; }
        public virtual ICollection<ItemTestMirror> Items { get; set; }
        public int IntField { get; set; }
    }
}
