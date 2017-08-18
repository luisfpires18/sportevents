using System;
using System.Collections.Generic;

namespace SE.DataTransfer
{
    public class Person
    {
        public Guid PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Nacionality { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImagePath { get; set; }
        public Guid TeamID { get; set; }

        // Navigation;
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual Team Team { get; set; }


    }
}