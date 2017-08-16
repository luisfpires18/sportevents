using System;

namespace tinc.Domain.Entities
{
    public enum TShirt { XXL = 6, XL = 5, L = 4, M = 3, S = 2, XS = 1, XXS = 0 }

    public class Enrollment
    {

        public Guid ID { get; set; }

        public TShirt Size { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string RegistrationBy { get; set; }

        public bool Status { get; set; }

        public string Notes { get; set; }

        public virtual Category Category { get; set; }
        public virtual Person Person { get; set; }
    }
}