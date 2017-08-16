using System;
using System.Collections.Generic;

namespace tinc.Domain.Entities
{
    public class Person
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        public string Gender { get; set; }
        public string City { get; set; }
        public string Nacionality { get; set; }
        public DateTime BirthDate { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
       // public virtual ICollection<Management> Managements { get; set; }
        public virtual Team Team { get; set; }


    }
}