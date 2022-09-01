namespace Server.Classi
{
    public class Cart
    {
        public int cart_id { get; set; }

        public int product_id { get; set; }

        public Product product { get; set; }

        public int quantity { get; set; }
    }
}
