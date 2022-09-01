using System.ComponentModel.DataAnnotations;

namespace Sito.Models
{
    public class QuantitySelector
    {
        public bool is_details_page { get; set; }

        public int prod_id { get; set; }

        [Display(Name = "Quantità:")]
        [Required(ErrorMessage = "Quantità richiesta")]
        public int quantity { get; set; }
    }

}
