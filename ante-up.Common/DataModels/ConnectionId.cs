using System;
using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class ConnectionId
    {
        [Key]
        public Guid Id { get; set; }

        public string Connection { get;  }

        public ConnectionId(string connectionId)
        {
            Connection = connectionId;
        }
        public string GetId()
        {
            return Id.ToString();
        }
    }
}