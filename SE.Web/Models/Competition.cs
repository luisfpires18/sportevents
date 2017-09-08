using System;
using System.Collections.Generic;

namespace SE.Web.Models
{
    public class Competition : Organization
    {
        public Guid CompetitionID { get; set; }
        public float Distance { get; set; }
        public Guid EventID { get; set; }

        // Navigation;
        public virtual Event Event { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}