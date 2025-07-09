namespace PlacesAPI.Models.Dto
{
    public class UpdatePlacesDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
