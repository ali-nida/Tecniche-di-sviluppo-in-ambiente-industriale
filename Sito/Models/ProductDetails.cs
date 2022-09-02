using System.ComponentModel.DataAnnotations;

namespace Sito.Models
{
    public class ProductDetails
    {

        // Conversion helper function
        public static ProductDetails fromClassi(ServiceReference2.Product source)
        {
            ProductDetails prod = new ProductDetails()
            {
                img_url = $"/Images/{source.product_id}.jpg",
                product_id = source.product_id,
                brand = source.brand,
                model = source.model,
                cpu = source.cpu,
                storage = source.storage,
                battery = source.battery,
                ram = source.ram,
                os = source.os,
                camera = source.camera,
                display = source.display,
                price = source.price,
                quantity = source.quantity,
            };

            switch(source.sim_count)
            {
                case 1:
                    prod.sim = "Single SIM";
                    break;
                case 2:
                    prod.sim = "Dual SIM";
                    break;
                case 3:
                    prod.sim = "Triple SIM";
                    break;
                case 4:
                    prod.sim = "Quad SIM";
                    break;
                default:
                    prod.sim = $"{source.sim_count} SIM";
                    break;
            }

            return prod;
        }

        public string img_url { get; set; }

        public int product_id { get; set; }

        public string brand { get; set; }

        public string model { get; set; }

        [Display(Name = "Processore")]
        public string cpu { get; set; }

        [Display(Name = "Memoria Interna")]
        public int storage { get; set; }

        [Display(Name = "Batteria")]
        public int battery { get; set; }

        [Display(Name = "Memoria RAM")]
        public int ram { get; set; }

        [Display(Name = "Sistema Operativo")]
        public string os { get; set; }

        [Display(Name = "Risoluzione Fotocamera")]
        public double camera { get; set; }

        [Display(Name = "Risoluzione Display")]
        public double display { get; set; }

        [Display(Name = "SIM")]
        public string sim { get; set; }

        [Display(Name = "Prezzo")]
        public decimal price { get; set; }

        [Display(Name = "Quantità")]
        public int quantity { get; set; }
    }

}