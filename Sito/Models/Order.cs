using System.ComponentModel.DataAnnotations;

namespace Sito.Models
{
    public class Order
    {

        // Conversion helper function
        public static Order fromClassi(ServiceReference2.Sale src, Product product)
        {
            return new Order()
            {
                product = product,
                quantity = src.quantity,
                date = src.date.ToString("dddd d MMMM yyyy"),
                address = src.address,
                zip_code = src.zip_code,
                credit_card = src.credit_card,
                price = src.price
            };
        }

        public Product product { get; set; }

        public int quantity { get; set; }

        public string date { get; set; }

        public string address { get; set; }

        public int zip_code { get; set; }

        public string credit_card { get; set; }

        public decimal price { get; set; }
    }
}