using System.ComponentModel.DataAnnotations;

namespace Sito.Models
{
    public class Userlist
    {
        public static Userlist fromClassi(ServiceReference2.User src)
        {
            return new Userlist()
            {
                user_id = src.user_id,
                username = src.username,
                email = src.email,
                admin = src.admin
            };
        }

        public int user_id { get; set; }

        [Display(Name = "Username")]
        public string username { get; set; }

        [Display(Name = "Indirizzo E-mail")]
        public string email { get; set; }

        [Display(Name = "Amministratore")]
        public bool admin { get; set; }

    }
}