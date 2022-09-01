using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Sito.Models
{
    public class AddProduct
    {
        // Conversion helper function
        public ServiceReference2.Product toInternalProduct()
        {
            try
            {
                return new ServiceReference2.Product()
                {
                    brand = brand,
                    model = model,
                    cpu = cpu,
                    storage = storage,
                    battery = battery,
                    ram = ram,
                    os = os,
                    camera = camera,
                    display = display,
                    sim_count = sim_count,
                    price = price,
                    quantity = quantity,
                };
            }
            catch
            {
                return null;
            }
        }

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
        public int storage { get; set; }

        [Display(Name = "Batteria")]
        [Required(ErrorMessage = "Batteria richiesta")]
        public int battery { get; set; }

        [Display(Name = "Memoria RAM")]
        [Required(ErrorMessage = "RAM richiesta")]
        public int ram { get; set; }

        [Display(Name = "Sistema Operativo")]
        [Required(ErrorMessage = "Sistema operativo richiesto")]
        [MaxLength(254, ErrorMessage = "Il sistema operativo non può essere più lungo di {1} caratteri")]
        public string os { get; set; }

        [Display(Name = "Risoluzione Fotocamera")]
        [Required(ErrorMessage = "Risoluzione fotocamera richiesta")]
        public double camera { get; set; }

        [Display(Name = "Dimensione Display")]
        [Required(ErrorMessage = "Dimensione display richiesta")]
        public double display { get; set; }

        [Display(Name = "Numero SIM")]
        [Required(ErrorMessage = "Numero SIM richiesto")]
        public int sim_count { get; set; }

        [Display(Name = "Prezzo")]
        [Required(ErrorMessage = "Prezzo richiesto")]
        public decimal price { get; set; }

        [Display(Name = "Pezzi Disponibili")]
        [Required(ErrorMessage = "Numero pezzi richiesto")]
        public int quantity { get; set; }

    }

}