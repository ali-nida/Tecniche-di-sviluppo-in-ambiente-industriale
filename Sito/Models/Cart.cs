namespace Sito.Models
{
    public class Cart
    {
        // Conversion helper function
        public static Cart fromClassi(ServiceReference2.Cart src)
        {
            return new Cart()
            {
                cart_id = src.cart_id,
                product = Product.fromClassi(src.product),
                quantity = src.quantity
            };
        }

        public int cart_id { get; set; }

        public Product product { get; set; }

        public int quantity { get; set; }
    }
}
