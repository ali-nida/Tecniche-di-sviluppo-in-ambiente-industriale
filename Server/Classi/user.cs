namespace Server.Classi
{
    public class User
    {
        public int user_id { get; set; }

        public string username { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public bool admin { get; set; }

        public string payment_method { get; set; }

        public string address { get; set; }
    }
}
