using System;
using System.Collections.Generic;
using SE.Domain.Entities.Enum;

namespace SE.Domain.Entities
{

    public class Enrollment
    {

        public Guid EnrollmentID { get; set; }
        public TShirt Size { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegistrationBy { get; set; }
        public bool Status { get; set; }
        public string Notes { get; set; }
        public Guid CategoryID { get; set; }
        public Guid PersonID { get; set; }

        // Navigation;
        public virtual Category Category { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}