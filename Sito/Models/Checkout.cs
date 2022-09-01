using System.ComponentModel.DataAnnotations;

namespace Sito.Models
{
    public class Checkout
    {
        [Display(Name = "Indirizzo")]
        [Required(ErrorMessage = "Indirizzo richiesto")]
        [MaxLength(254, ErrorMessage = "L'indirizzo non può essere più lungo di {1} caratteri")]
        public string address { get; set; }

        [Display(Name = "Codice Postale")]
        [Required(ErrorMessage = "Codice postale richiesto")]
        [DataType(DataType.PostalCode)]
        public int zip_code { get; set; }

        [Display(Name = "Carta di Credito")]
        [Required(ErrorMessage = "Carta di credito richiesta")]
        [RegularExpression("/^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\\d{3})\\d{11})$/", ErrorMessage = "Carta di credito non valida")]
        public string credit_card { get; set; }

        [Display(Name = "Prezzo Totale")]
        public decimal price { get; set; }
    }
}