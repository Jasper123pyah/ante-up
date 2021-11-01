using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class ConnectionId
    {
        [Key]
        public string Id { get; set; }

        public string Connection { get; set; }
    }
}