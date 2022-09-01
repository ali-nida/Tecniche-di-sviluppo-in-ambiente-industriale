namespace Sito.Models
{
    public class Product
    {
        public static Product fromClassi(ServiceReference2.Product source)
        {
            Product prod = new Product()
            {
                product_id = source.product_id,
                img_url = $"/Images/{source.product_id}.jpg",
                brand = source.brand,
                model = source.model,
                price = source.price,
                quantity = source.quantity,
            };

            return prod;
        }

        public int product_id { get; set; }

        public string img_url { get; set; }

        public string brand { get; set; }

        public string model { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

    }

}