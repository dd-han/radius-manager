using System;
using System.Collections.Generic;

namespace RadiusManager.Models
{
    public partial class RadUserGroup
    {
        public string Username { get; set; }
        public string GroupName { get; set; }
        public int Priority { get; set; }
    }
}
