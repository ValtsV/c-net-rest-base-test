using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dot_net_backend_test.Models.DataModels
{
    public class Category: BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
