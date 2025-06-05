namespace TourismRecommender.Entities.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Attributes Attributes { get; set; } = new();

        public class Attributes
        {
            public string? Climate { get; set; }
            public string? Sea { get; set; }
            public string? ColorfulStreets { get; set; }
            public string? Culture { get; set; }
            public string? History { get; set; }
            public string? Budget { get; set; }
            public string? Accommodation { get; set; }
            public string? Nightlife { get; set; }
            public string? LocalCuisine { get; set; }
            public string? NatureIntegration { get; set; }
            public string? GroupTrip { get; set; }
            public string? TripDuration { get; set; }
            public string? VisaRequirement { get; set; }
            public string? Shopping { get; set; }
            public string? Romantic { get; set; }
            public string? DirectFlight { get; set; }
        }
    }
}
