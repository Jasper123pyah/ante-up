namespace ante_up.Common.ApiModels
{
    public class ApiAccountInfo
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int Balance { get; set; }
        public bool InWager { get; set; }
    }
}