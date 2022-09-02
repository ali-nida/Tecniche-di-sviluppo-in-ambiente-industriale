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
        [RegularExpression("\\d{4}-\\d{4}-\\d{4}-\\d{4}", ErrorMessage = "Carta di credito non valida")]
        public string credit_card { get; set; }

        [Display(Name = "Prezzo Totale")]
        public decimal price { get; set; }
    }
}