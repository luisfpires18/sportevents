using System;
using System.Collections.Generic;

namespace SE.Domain.Entities
{
    public class Event : Organization
    {
        public Guid EventID { get; set; }
        public string Local { get; set; }
        public string Website { get; set; }
        public DateTime EventDate { get; set; }
        public string ImagePath { get; set; }
        public string FilePath { get; set; }
        public bool IsActive { get; set; }
        public Guid SportID { get; set; }

        // Navigation;
        public virtual Sport Sport { get; set; }
        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<Extra> Extras { get; set; }

    }
}