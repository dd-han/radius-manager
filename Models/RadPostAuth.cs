using System;
using System.Collections.Generic;

namespace RadiusManager.Models
{
    public partial class RadPostAuth
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Reply { get; set; }
        public DateTime AuthDate { get; set; }
    }
}
