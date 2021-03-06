using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dot_net_backend_test.Models.DataModels
{
    public class Student: BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime Dob { get; set; }
        
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
