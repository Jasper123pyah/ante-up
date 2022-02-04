    using System;
    using System.ComponentModel.DataAnnotations;

    public class Payer
    {
        [Key]
        public Guid Id { get; set; }
        public Name name { get; set; }
        public string email_address { get; set; }
        public string payer_id { get; set; }
        public Address address { get; set; }
    }
