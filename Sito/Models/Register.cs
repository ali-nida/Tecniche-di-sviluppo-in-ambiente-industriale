using System.ComponentModel.DataAnnotations;

namespace Sito.Models
{
    public class Register
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

    }
}