using System;
using System.Collections.Generic;

namespace RadiusManager.Models
{
    public partial class RadGroupReply
    {
        public uint Id { get; set; }
        public string GroupName { get; set; }
        public string Attribute { get; set; }
        public string Op { get; set; }
        public string Value { get; set; }
    }
}
