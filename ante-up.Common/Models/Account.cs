using System;
using System.ComponentModel.DataAnnotations;
namespace ante_up.Common.Models
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
    }
}