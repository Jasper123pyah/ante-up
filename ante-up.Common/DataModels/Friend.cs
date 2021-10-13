using System.ComponentModel.DataAnnotations;

namespace ante_up.Common.DataModels
{
    public class Friend
    {
        [Key]
        public string Id { get; set; }
        public string PlayerId { get; set; }
    }
}