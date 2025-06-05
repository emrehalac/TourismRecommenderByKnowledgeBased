using TourismRecommender.Entities.Models;

namespace TourismRecommender.DataAccess.Repositories
{
    public interface IDestinationRepository
    {
        IEnumerable<Destination> GetAll();
        Destination? GetById(int id);
        void Add(Destination destination);
    }
}
