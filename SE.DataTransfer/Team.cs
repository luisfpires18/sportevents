using System;
using System.Collections.Generic;

namespace SE.DataTransfer
{
    public class Team
    {
        public Guid TeamID { get; set; }
        public string Name { get; set; }

        // Navigation;
        public virtual ICollection<Person> Persons { get; set; }
    }
}