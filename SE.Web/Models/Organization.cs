using System.ComponentModel.DataAnnotations;

namespace SE.Web.Models
{
    public class Organization : ModelsBase
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Responsible { get; set; }
    }
}