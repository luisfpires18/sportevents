using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SE.Web.Models;

namespace SE.Web.ViewModels
{
    public class EventData
    {
       // public IEnumerable<Sport> Sports { get; set; }

        public List<Event> Events { get; set; }
       // public Event Event { get; set; }

        public List<Competition> Competitions { get; set; }
        public List<Extra> Extras { get; set; }
        public List<Category> Categories { get; set; }
    }
}
