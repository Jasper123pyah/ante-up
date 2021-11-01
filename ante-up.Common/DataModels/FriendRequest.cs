using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class FriendRequest
    {
        [Key]
        public string Id { get; set; }
        public string RequesterId { get; set; }
    }
}