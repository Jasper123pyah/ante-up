using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class PaypalAction
    {
        [Key]
        public Guid Id { get; set; }
        public string PaypalId { get; set; }
        public string Status { get; set; }
        public DateTime Time { get; set; }
    }
}