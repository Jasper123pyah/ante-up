    using System;
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        public string address_line_1 { get; set; }
        public string admin_area_2 { get; set; }
        public string admin_area_1 { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
    }
