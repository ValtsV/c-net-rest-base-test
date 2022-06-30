using System.ComponentModel.DataAnnotations;

namespace dot_net_backend_test.Models.DataModels
{
    public class BaseEntity
    {

        [Required]
        [Key]
        public int Id { get; set; }

        //public int UserID { get; set; }
        //public virtual User CreatedBy { get; set; } = new User();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public User UpdatedBy { get; set; } = new User();
        public string UpdatedBy { get; set; } = String.Empty;
        public DateTime? UpdatedAt { get; set; }
        //public User DeletedBy { get; set; } = new User();
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
