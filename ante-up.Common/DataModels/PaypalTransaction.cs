using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class PaypalTransaction
    {
        [Key]
        public Guid Id { get; set; }
        public string PaypalId { get; set; }
        public string CaptureId { get; set; }
        public string PayerId { get; set; }
        public float Value { get; set; }
        public int Credits { get; set; }
        public string Ip { get; set; }
        public List<PaypalAction> Actions { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }


}