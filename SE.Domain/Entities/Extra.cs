using System;
using System.Collections.Generic;

namespace SE.Domain.Entities
{
    public class Extra : Organization
    {
        public Guid ExtraID { get; set; }
        public float Price { get; set; }
        public Guid EventID { get; set; }

        //Navigation;
        public virtual Event Event { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}