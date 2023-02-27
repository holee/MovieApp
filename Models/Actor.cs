namespace MovieApp.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public int AddressRefId { get; set; } 
    }
}
