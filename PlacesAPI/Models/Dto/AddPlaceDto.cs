namespace PlacesAPI.Models.Dto
{
    public class AddPlaceDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
