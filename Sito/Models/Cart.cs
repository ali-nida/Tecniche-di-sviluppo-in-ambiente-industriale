namespace Sito.Models
{
    public class Cart
    {
        public static Cart fromClassi(ServiceReference2.Cart src)
        {
            return new Cart()
            {
                product = Product.fromClassi(src.product),
                quantity = src.quantity
            };
        }

        public Product product { get; set; }

        public int quantity { get; set; }
    }
}
