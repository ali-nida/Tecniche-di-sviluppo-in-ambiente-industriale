namespace Server.Classi
{
    public class Sale
    {
        public int sale_id { get; set; }

        public int user_id { get; set; }

        public int product_id { get; set; }

        public int quantity { get; set; }

        public System.DateTime date { get; set; }

        public string address { get; set; }

        public int zip_code { get; set; }

        public string credit_card { get; set; }

    }
}
