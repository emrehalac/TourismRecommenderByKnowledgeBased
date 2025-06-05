using TourismRecommender.Entities.Models;

namespace TourismRecommender.DataAccess.Repositories
{
    public class InMemoryDestinationRepository : IDestinationRepository
    {
        private readonly List<Destination> _destinations = new();

        public IEnumerable<Destination> GetAll() => _destinations;

        public Destination? GetById(int id) => _destinations.FirstOrDefault(d => d.Id == id);

        public void Add(Destination destination)
        {
            destination.Id = _destinations.Count + 1;
            _destinations.Add(destination);
        }
    }
}
