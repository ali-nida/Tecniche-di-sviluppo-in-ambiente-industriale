using System.ComponentModel.DataAnnotations;

namespace Sito.Models
{
    public class Login
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

    }
}