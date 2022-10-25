using System;
using System.Collections.Generic;

namespace GreenLeavesAPI.DataGLModels
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string City { get; set; } = null!;
        public DateTime Fecha { get; set; }
    }
}
