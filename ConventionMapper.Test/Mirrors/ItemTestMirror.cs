using ConventionMapper.Test.Mirrors.Base;
using System;

namespace ConventionMapper.Test.Mirrors
{
    public class ItemTestMirror : BaseTestMirror
    {
        public HeaderTestMirror Header { get; set; }
        public string StringField { get; set; }
        public string AnotherStringField { get; set; }
    }
}
