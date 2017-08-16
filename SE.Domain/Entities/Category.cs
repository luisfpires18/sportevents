using System;
using System.Collections.Generic;

namespace tinc.Domain.Entities
{
    public class Category : Organization
    {
        public Guid ID { get; set; }
        public string Gender { get; set; }
        public string AthleteType { get; set; }
        public int NumberOfWinners { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}