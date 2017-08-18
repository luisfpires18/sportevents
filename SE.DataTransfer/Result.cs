using System;

namespace SE.DataTransfer
{
    public class Result : Organization
    {
        public Guid ResultID { get; set; }
        public Guid PersonID { get; set; }
        public Guid CategoryID { get; set; }

        // Navigation;
        public virtual Person Person { get; set; }
        public virtual Category Category { get; set; }
    }
}