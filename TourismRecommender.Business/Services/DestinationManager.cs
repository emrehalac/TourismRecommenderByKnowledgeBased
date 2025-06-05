using TourismRecommender.Entities.Models;
using TourismRecommender.DataAccess.Repositories;

namespace TourismRecommender.Business.Services
{
    public class DestinationManager : IDestinationService
    {
        private readonly IDestinationRepository _repository;

        public DestinationManager(IDestinationRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Destination> GetAll() => _repository.GetAll();

        public Destination? GetById(int id) => _repository.GetById(id);

        public void Add(Destination destination) => _repository.Add(destination);
    }
}
