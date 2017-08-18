using System;
using System.Collections.Generic;

namespace SE.DataTransfer
{
    public class Sport : Organization
    {
        public Guid SportID { get; set; }

        // Navigation;
        public virtual ICollection<Event> Events { get; set; }
    }
}