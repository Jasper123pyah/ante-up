    using System;
    using System.Collections.Generic;

    public class PaypalResponseRoot
    {
        public string id { get; set; }
        public string intent { get; set; }
        public string status { get; set; }
        public List<PurchaseUnit> purchase_units { get; set; }
        public Payer payer { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public List<Link> links { get; set; }
    }
