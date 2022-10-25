using System;
using System.Collections.Generic;

namespace GreenLeavesAPI.DataGLModels
{
    public partial class Administrator
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Pwd { get; set; } = null!;
        public string AdminType { get; set; } = null!;
    }
}
