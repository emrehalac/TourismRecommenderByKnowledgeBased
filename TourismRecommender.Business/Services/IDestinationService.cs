using TourismRecommender.Entities.Models;

namespace TourismRecommender.Business.Services
{
    public interface IDestinationService
    {
        IEnumerable<Destination> GetAll();
        Destination? GetById(int id);
        void Add(Destination destination);
    }
}
