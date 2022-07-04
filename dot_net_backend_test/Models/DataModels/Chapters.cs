using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dot_net_backend_test.Models.DataModels
{
    public class Chapters: BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }

        [Required]
        public ICollection<Theme> Themes { get; set; } = new List<Theme>();
    }
}
