using System;

namespace SE.Web.Models
{
    public class Sport : Organization
    {
        public Guid ID { get; set; }
        //public virtual ICollection<Event> Events { get; set; }
    }
}