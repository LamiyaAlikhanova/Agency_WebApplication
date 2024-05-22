using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Agency_WebAppliaction.Models
{
    public class Service
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string Title { get; set; }
        [MinLength(10)]
        [MaxLength(50)]
        public string Description { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }
    }
}
