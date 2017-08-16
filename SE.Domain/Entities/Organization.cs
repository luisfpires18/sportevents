using System;
using System.Collections.Generic;
using System.Linq;
namespace tinc.Domain.Entities
{
    public class Organization
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Responsible { get; set; }
    }
}