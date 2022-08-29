using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Sito.Models
{
    public class AddProduct
    {
        [Display(Name = "Immagine")]
        [Required(ErrorMessage = "Immagine richiesta")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase image_file { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Marca richiesta")]
        [MaxLength(254, ErrorMessage = "La marca non può essere più lunga di {1} caratteri")]
        public string brand { get; set; }

        [Display(Name = "Modello")]
        [Required(ErrorMessage = "Modello richiesto")]
        [MaxLength(254, ErrorMessage = "Il modello non può essere più lungo di {1} caratteri")]
        public string model { get; set; }

        [Display(Name = "Processore")]
        [Required(ErrorMessage = "Processore richiesto")]
        [MaxLength(254, ErrorMessage = "Il processore non può essere più lungo di {1} caratteri")]
        public string cpu { get; set; }

        [Display(Name = "Memoria Interna")]
        [Required(ErrorMessage = "Memoria richiesta")]
        [RegularExpression("\\d", ErrorMessage = "Memoria non valida")]
        public int storage { get; set; }

        [Display(Name = "Batteria")]
        [Required(ErrorMessage = "Batteria richiesta")]
        [RegularExpression("\\d", ErrorMessage = "Batteria non valida")]
        public int battery { get; set; }

        [Display(Name = "Memoria RAM")]
        [Required(ErrorMessage = "RAM richiesta")]
        [RegularExpression("\\d", ErrorMessage = "RAM non valida")]
        public int ram { get; set; }

        [Display(Name = "Sistema Operativo")]
        [Required(ErrorMessage = "Sistema operativo richiesto")]
        [MaxLength(254, ErrorMessage = "Il sistema operativo non può essere più lungo di {1} caratteri")]
        public string os { get; set; }

        [Display(Name = "Risoluzione Fotocamera")]
        [Required(ErrorMessage = "Risoluzione fotocamera richiesta")]
        [RegularExpression("\\d*[,.]?\\d+?", ErrorMessage = "Risoluzione non valida")]
        public double camera { get; set; }

        [Display(Name = "Dimensione Display")]
        [Required(ErrorMessage = "Dimensione display richiesta")]
        [RegularExpression("\\d*[,.]?\\d+?", ErrorMessage = "Dimensione non valida")]
        public double display { get; set; }

        [Display(Name = "Numero SIM")]
        [Required(ErrorMessage = "Numero SIM richiesto")]
        [RegularExpression("\\d", ErrorMessage = "Numero SIM non valido")]
        public string sim { get; set; }

        [Display(Name = "Prezzo")]
        [Required(ErrorMessage = "Prezzo richiesto")]
        [RegularExpression("\\d*[,.]?\\d+?", ErrorMessage = "Prezzo non valido")]
        public decimal price { get; set; }

        [Display(Name = "Pezzi Disponibili")]
        [Required(ErrorMessage = "Numero pezzi richiesto")]
        [RegularExpression("\\d", ErrorMessage = "Numero pezzi non valido")]
        public int quantity { get; set; }

    }

}