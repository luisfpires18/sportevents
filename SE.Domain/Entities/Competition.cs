using System;
using System.Collections.Generic;

namespace tinc.Domain.Entities
{
    public class Competition : Organization
    {
        public Guid ID { get; set; }
        public float Distance { get; set; }
        public float Price { get; set; }
        public virtual Event Event { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}