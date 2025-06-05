using System.Text.Json;
using TourismRecommender.Entities.Models;
using TourismRecommenderByKnowledgeBased.Models;

namespace TourismRecommenderByKnowledgeBased.Services
{
    public class RuleEngineService
    {
        private readonly List<Destination> _destinations = new();

        public RuleEngineService()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "destinations.json");
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var items = JsonSerializer.Deserialize<List<Destination>>(json, options);
                if (items != null)
                    _destinations = items;
            }
        }

        public Destination? GetBestDestination(UserPrefs prefs)
        {
            int bestScore = -1;
            Destination? best = null;
            foreach (var dest in _destinations)
            {
                var attr = dest.Attributes;
                int score = 0;
                if (prefs.Climate != null && prefs.Climate.Equals(attr.Climate, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.Sea != null && prefs.Sea.Equals(attr.Sea, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.ColorfulStreets != null && prefs.ColorfulStreets.Equals(attr.ColorfulStreets, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.Culture != null && prefs.Culture.Equals(attr.Culture, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.History != null && prefs.History.Equals(attr.History, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.Budget != null && prefs.Budget.Equals(attr.Budget, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.Accommodation != null && prefs.Accommodation.Equals(attr.Accommodation, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.Nightlife != null && prefs.Nightlife.Equals(attr.Nightlife, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.LocalCuisine != null && prefs.LocalCuisine.Equals(attr.LocalCuisine, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.NatureIntegration != null && prefs.NatureIntegration.Equals(attr.NatureIntegration, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.GroupTrip != null && prefs.GroupTrip.Equals(attr.GroupTrip, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.TripDuration != null && prefs.TripDuration.Equals(attr.TripDuration, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.VisaRequirement != null && prefs.VisaRequirement.Equals(attr.VisaRequirement, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.Shopping != null && prefs.Shopping.Equals(attr.Shopping, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.Romantic != null && prefs.Romantic.Equals(attr.Romantic, StringComparison.OrdinalIgnoreCase)) score++;
                if (prefs.DirectFlight != null && prefs.DirectFlight.Equals(attr.DirectFlight, StringComparison.OrdinalIgnoreCase)) score++;

                if (score > bestScore)
                {
                    bestScore = score;
                    best = dest;
                }
            }

            return best;
        }
    }
}
