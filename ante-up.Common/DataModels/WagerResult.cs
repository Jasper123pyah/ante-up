using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class WagerResult
    {
        [Key] 
        public Guid Id { get; set; }
        public string GameName { get; set; }
        public int Earnings { get; set; }
        public DateTime WagerDate { get; set; }

        public WagerResult()
        {
        }

        public WagerResult(string gameName, int earnings)
        {
            GameName = gameName;
            Earnings = earnings;
            WagerDate = DateTime.Now;
        }
    }
}