using System;

namespace SE.DataTransfer
{
    public class Request
    {
        public Guid RequestID { get; set; }

        public string RequestType { get; set; }
        public string Subject { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid? PersonID { get; set; }

        // Navigation;
        public virtual Person Person { get; set; }
    }
}
