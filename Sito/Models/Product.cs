using System.ComponentModel.DataAnnotations;

namespace Sito.Models
{
    public class Product
    {
        public static Product fromClassi(ServiceReference2.Product source)
        {
            Product prod = new Product()
            {
                img_url = $"/Images/{source.product_id}.jpg",
                brand = source.brand,
                model = source.model,
                price = source.price,
                quantity = source.quantity
            };

            return prod;
        }

        [Display(Name = "Immagine")]
        public string img_url { get; set; }

        [Display(Name = "Marca")]
        public string brand { get; set; }

        [Display(Name = "Modello")]
        public string model { get; set; }

        [Display(Name = "Prezzo")]
        public decimal price { get; set; }

        [Display(Name = "Pezzi Disponibili")]
        public int quantity { get; set; }

    }

}