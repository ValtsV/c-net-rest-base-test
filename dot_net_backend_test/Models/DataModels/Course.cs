using System.ComponentModel.DataAnnotations;

namespace dot_net_backend_test.Models.DataModels
{
    public enum Levels
    {
        Basic = 0,
        Intermediate = 1,
        Advanced = 2
    }

    public class Course: BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string DescriptionShort { get; set; } = string.Empty;
        [Required]
        public string DescriptionFull { get; set; } = string.Empty;
        [Required]
        public Levels Level { get; set; } = Levels.Basic;
    }
}
