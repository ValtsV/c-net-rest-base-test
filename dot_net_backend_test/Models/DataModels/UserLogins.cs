using System.ComponentModel.DataAnnotations;

namespace dot_net_backend_test.Models.DataModels
{
    public class UserLogins
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
