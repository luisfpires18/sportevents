using System;

namespace SE.Web.Models
{
    public class Sport : Organization
    {
        public Guid SportID { get; set; }

        public bool isSelected { get; set; }

        //public virtual ICollection<Event> Events { get; set; }
    }
}