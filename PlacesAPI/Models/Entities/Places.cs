namespace PlacesAPI.Models.Entities
{
    public class Places
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
