using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class FriendRequest
    {
        [Key]
        public Guid Id { get;  }
        public string RequesterId { get;set; }
        public string RequesterName { get;set; }

        public FriendRequest(){}
        public FriendRequest(string requesterId, string requesterName)
        {
            RequesterId = requesterId;
            RequesterName = requesterName;
        }
        
    }
}