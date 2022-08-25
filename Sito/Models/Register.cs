using System.ComponentModel.DataAnnotations;

namespace Sito.Models
{
    public class Register
    {

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username richiesto")]
        [MinLength(4, ErrorMessage = "Lo username non può essere più corto di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "Lo username non può essere più lungo di {1} caratteri")]
        public string username { get; set; }

        [Display(Name = "Indirizzo E-mail")]
        [Required(ErrorMessage = "Indirizzo e-mail richiesto")]
        [EmailAddress(ErrorMessage = "Indirizzo e-mail non valido")]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password richiesta")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "La password non può essere più corta di {1} caratteri")]
        [MaxLength(254, ErrorMessage = "La password non può essere più lunga di {1} caratteri")]
        public string password { get; set; }

        [Display(Name = "Ripeti Password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Le due password non corrispondono")]
        public string repeat_password { get; set; }

    }
}