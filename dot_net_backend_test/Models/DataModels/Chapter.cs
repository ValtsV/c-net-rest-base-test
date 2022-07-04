using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dot_net_backend_test.Models.DataModels
{
    public class Chapter: BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }

        [Required]
        public string Chapters = string.Empty;
    }
}
