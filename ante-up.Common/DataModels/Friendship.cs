using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Friendship
    {
        [Key]
        public string Id { get; set; }
        public Chat Chat { get; set; }
        public string AccountId1 { get; set; }
        public string AccountId2 { get; set; }
    }
}