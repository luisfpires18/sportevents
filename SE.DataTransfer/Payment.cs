using System;

namespace SE.DataTransfer
{
    public class Payment
    {
        public Guid PaymentID { get; set; }
        public Guid ExtraID { get; set; }
        public Guid EnrollmentID { get; set; }

        // Navigation
        public virtual Extra Extra { get; set; }
        public virtual Enrollment Enrollment { get; set; }

    }
}
