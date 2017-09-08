using System;
using System.Collections.Generic;
using SE.Domain.Entities;

namespace SE.Web.Models
{
    public class Extra : Domain.Entities.Organization
    {
        public Guid ExtraID { get; set; }
        public float Price { get; set; }
        public Guid EventID { get; set; }

        //Navigation;
        public virtual Event Event { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}