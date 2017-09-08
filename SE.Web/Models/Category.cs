using System;
using System.Collections.Generic;
using SE.DataTransfer.Enum;
using SE.Domain.Entities;

namespace SE.Web.Models
{
    public class Category : Domain.Entities.Organization
    {
        public Guid CategoryID { get; set; }
        public Gender Gender { get; set; }
        public string AthleteType { get; set; }
        public int NumberOfWinners { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public Guid CompetitionID { get; set; }


        // Navigation;
        public virtual Competition Competition { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}