using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SE.Web.Models
{
    public class Event : Organization
    {
        public Guid EventID { get; set; }
        public string Local { get; set; }
        public string Website { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }
        public string ImagePath { get; set; }
        public string FilePath { get; set; }
        public bool IsActive { get; set; }

        [Display(Name = "Sport")]
        public Guid SportID { get; set; }

        // Navigation;
        public virtual Sport Sport { get; set; }
        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<Extra> Extras { get; set; }

    }
}