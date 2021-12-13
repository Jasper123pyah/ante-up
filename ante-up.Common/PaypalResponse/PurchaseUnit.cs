    public class PurchaseUnit
    {
        public string reference_id { get; set; }
        public Amount amount { get; set; }
        public Payee payee { get; set; }
        public string description { get; set; }
        public Shipping shipping { get; set; }
        public Payments payments { get; set; }
    }
